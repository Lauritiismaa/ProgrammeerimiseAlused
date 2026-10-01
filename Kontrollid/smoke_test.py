"""Veebiprojektide HTTP-kontroll; nõuab Python 3, .NET 10 ja eelnevat build'i."""
import html
import http.cookiejar
import json
import os
from pathlib import Path
import re
import shutil
import subprocess
import tempfile
import time
import urllib.error
import urllib.parse
import urllib.request

ROOT = Path(__file__).resolve().parents[1]
DOTNET = shutil.which('dotnet')
if not DOTNET:
    raise SystemExit('dotnet puudub PATH-ist')


def request(base, path, method='GET', body=None, opener=None, form=False):
    headers = {}
    if body is not None:
        body = (urllib.parse.urlencode(body) if form else json.dumps(body)).encode()
        headers['Content-Type'] = 'application/x-www-form-urlencoded' if form else 'application/json'
    req = urllib.request.Request(base + path, data=body, headers=headers, method=method)
    try:
        response = (opener or urllib.request.build_opener()).open(req, timeout=10)
    except urllib.error.HTTPError as error:
        response = error
    with response:
        return response.status, response.read().decode(), response.headers


def start(project, port, temp):
    env = os.environ.copy()
    env['ASPNETCORE_ENVIRONMENT'] = 'Development'
    env['ConnectionStrings__MvcMovieContext'] = f'Data Source={temp}/movies.db'
    logfile = open(Path(temp) / f'{project}.log', 'a')
    proc = subprocess.Popen([DOTNET, 'run', '--no-build', '--no-launch-profile',
                             '--project', str(ROOT / 'Tooleht2' / project),
                             '--urls', f'http://127.0.0.1:{port}'],
                            env=env, stdout=logfile, stderr=subprocess.STDOUT)
    base = f'http://127.0.0.1:{port}'
    for _ in range(150):
        if proc.poll() is not None:
            logfile.close()
            raise RuntimeError(Path(temp, f'{project}.log').read_text())
        try:
            request(base, '/')
            return proc, logfile, base
        except (urllib.error.URLError, TimeoutError):
            time.sleep(0.1)
    stop(proc, logfile)
    raise RuntimeError(f'{project} ei käivitunud')


def stop(proc, logfile):
    proc.terminate()
    try:
        proc.wait(timeout=10)
    except subprocess.TimeoutExpired:
        proc.kill()
        proc.wait()
    logfile.close()


def token(opener, base, path):
    status, page, _ = request(base, path, opener=opener)
    assert status == 200, (path, status)
    match = re.search(r'name="__RequestVerificationToken"[^>]*value="([^"]+)"', page)
    assert match, 'Puuduv CSRF token'
    return html.unescape(match[1])


def test_api(base):
    status, body, _ = request(base, '/api/todoitems')
    assert status == 200 and json.loads(body) == []
    status, body, headers = request(base, '/api/todoitems', 'POST',
                                   {'id': 999, 'name': 'Õpi C#', 'isComplete': False, 'secret': 'peidetud'})
    item = json.loads(body)
    assert status == 201 and item['id'] != 999 and 'secret' not in item
    assert headers['Location'].endswith('/' + str(item['id']))
    path = '/api/todoitems/' + str(item['id'])
    assert request(base, path)[0] == 200
    assert request(base, path, 'PUT', {'id': 999, 'name': 'Vale ID'})[0] == 400
    assert request(base, '/api/todoitems', 'POST', {'name': ''})[0] == 400
    assert request(base, '/api/todoitems', 'POST', {'name': 'x' * 201})[0] == 400
    assert request(base, path, 'PUT', {'id': item['id'], 'name': 'Valmis', 'isComplete': True})[0] == 204
    changed = json.loads(request(base, path)[1])
    assert changed['name'] == 'Valmis' and changed['isComplete'] is True
    assert request(base, path, 'DELETE')[0] == 204
    assert request(base, path)[0] == 404
    assert request(base, path, 'PUT', {'id': item['id'], 'name': 'Puuduv'})[0] == 404
    assert request(base, path, 'DELETE')[0] == 404
    assert request(base, '/openapi/v1.json')[0] == 200
    # Jätame kirje, et pärast taaskäivitamist kontrollida InMemory käitumist.
    assert request(base, '/api/todoitems', 'POST', {'name': 'Ajutine'})[0] == 201
    print('PASS TodoApi: CRUD, DTO, vigane sisend, 400/404, OpenAPI')


def test_movies(base):
    opener = urllib.request.build_opener(urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()))
    status, body, _ = request(base, '/Movies')
    assert status == 200 and 'Kevade' in body and 'Interstellar' in body
    for url in ['/Movies/Create', '/Movies/Edit/1', '/Movies/Details/1', '/Movies/Delete/1', '/HelloWorld', '/css/site.css', '/lib/jquery/dist/jquery.min.js', '/lib/jquery-validation/dist/jquery.validate.min.js', '/lib/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js']:
        assert request(base, url)[0] == 200, url
    assert request(base, '/Movies/Details/999999')[0] == 404
    welcome = request(base, '/HelloWorld/Welcome?name=Lauri&numTimes=3')[1]
    assert welcome.count('Tere, Lauri!') == 3
    form = {'Title': 'Kontrollfilm', 'ReleaseDate': '2024-01-01', 'Genre': 'Draama', 'Price': '9.99', 'Rating': 'PG'}
    assert request(base, '/Movies/Create', 'POST', form, opener, True)[0] == 400
    form['__RequestVerificationToken'] = token(opener, base, '/Movies/Create')
    invalid = dict(form, Title='X', Price='101')
    status, body, _ = request(base, '/Movies/Create', 'POST', invalid, opener, True)
    assert status == 200 and 'field-validation-error' in body
    assert request(base, '/Movies/Create', 'POST', form, opener, True)[0] == 200
    status, body, _ = request(base, '/Movies?searchString=Kontrollfilm&movieGenre=Draama')
    assert status == 200 and 'Kontrollfilm</td>' in body and 'Kevade</td>' not in body
    match = re.search(r'href="/Movies/Details/(\d+)"', body)
    assert match, body
    id_ = match[1]
    edit = dict(form, Id=id_, Title='Muudetudfilm', Price='11.50')
    edit['__RequestVerificationToken'] = token(opener, base, '/Movies/Edit/' + id_)
    assert request(base, '/Movies/Edit/' + id_, 'POST', edit, opener, True)[0] == 200
    assert 'Muudetudfilm' in request(base, '/Movies/Details/' + id_)[1]
    bad_edit = dict(edit, Price='0')
    assert 'field-validation-error' in request(base, '/Movies/Edit/' + id_, 'POST', bad_edit, opener, True)[1]
    delete = {'Id': id_, '__RequestVerificationToken': token(opener, base, '/Movies/Delete/' + id_)}
    assert request(base, '/Movies/Delete/' + id_, 'POST', delete, opener, True)[0] == 200
    assert request(base, '/Movies/Details/' + id_)[0] == 404
    form['Title'] = 'Pusivfilm'
    form['__RequestVerificationToken'] = token(opener, base, '/Movies/Create')
    assert request(base, '/Movies/Create', 'POST', form, opener, True)[0] == 200
    print('PASS Movies: CRUD, otsing, filtrid, valideerimine, CSRF, tervitus, staatilised failid')


with tempfile.TemporaryDirectory(prefix='programmeerimine-test-') as temp:
    for project, port, test in [('Movies', 15101, test_movies), ('TodoApi', 15102, test_api)]:
        proc, logfile, base = start(project, port, temp)
        try:
            test(base)
        finally:
            stop(proc, logfile)
        proc, logfile, base = start(project, port, temp)
        try:
            if project == 'Movies':
                assert 'Pusivfilm</td>' in request(base, '/Movies?searchString=Pusivfilm')[1]
                print('PASS Movies: SQLite andmed säilivad taaskäivitamisel')
            else:
                assert json.loads(request(base, '/api/todoitems')[1]) == []
                print('PASS TodoApi: InMemory andmed kaovad taaskäivitamisel')
        finally:
            stop(proc, logfile)
print('Kõik HTTP-kontrollid läbisid edukalt.')
