# Lahenduste kontrollimine

## Korratav kontroll

Vajalikud on .NET 10 SDK ja Python 3.

```sh
dotnet build ProgrammeerimiseAlused.sln -m:1
python Kontrollid/smoke_test.py
```

HTTP-kontroll käivitab rakendused ise, kasutab ajutist SQLite andmebaasi ning peatab protsessid ka vea korral. Pordid 15101 ja 15102 peavad olema vabad.

## Kontrollitud käitumine

- Kogu solution kompileerus ühe MSBuild tööprotsessiga (`-m:1`): 0 viga, 0 hoiatust.
- TereMaailm tervitab nime `Lauri` sisestamisel nimepidi.
- ArvamisMang: `50` on liiga suur, `20` liiga väike, `tere` on vigane sisend ja `42` lõpetab mängu.
- Movies: algandmed, kõik CRUD-vaated, lisamine, muutmine, kustutamine, puuduva ID 404.
- Movies: kombineeritud pealkirja/žanri otsing, vigase hinna ja pealkirja tagasilükkamine, CSRF-kaitse.
- Movies: tervituskontroller ja kohalikud JavaScripti/CSS-failid.
- Movies: SQLite kirje säilib taaskäivitamisel.
- TodoApi: CRUD, Location päis, serveri loodud ID, DTO kaudu Secret välja peitmine.
- TodoApi: vigane nimi, erinevad ID-d, puuduv kirje ning vastavad 400/404 vastused.
- TodoApi: OpenAPI kirjeldus ning InMemory andmete kadumine taaskäivitamisel.

Postmani kogus on täiendavad testilaused, kuid Postmani graafilist rakendust selles keskkonnas ei käivitatud. Veebivaadete HTML-i ja serveri käitumist kontrolliti HTTP kaudu; brauseri visuaalkontrolli ei tehtud.
