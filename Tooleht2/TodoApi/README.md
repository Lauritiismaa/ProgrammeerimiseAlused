# TodoApi

Lauri Tiismaa

Kontrolleripõhine ASP.NET Core Web API Microsofti [Web API juhendi](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-10.0) teemade põhjal.

## Käivitamine

Vajalik: .NET 10 SDK. Hoidla juurkaustas:

```sh
dotnet run --project Tooleht2/TodoApi --launch-profile http
```

API: http://localhost:5102/api/todoitems . Alguses on vastus `[]`.
OpenAPI kirjeldus arenduskeskkonnas: http://localhost:5102/openapi/v1.json .
HTTPS-profiil kasutab porti 7102; vajadusel käivita `dotnet dev-certs https --trust`.

## Postman

1. Impordi `TodoApi.postman_collection.json` (Postman → Import).
2. Käivita API ning vali imporditud kogu.
3. Käivita päringud numbrite järjekorras või kasuta Collection Runnerit.
4. Esimene päring salvestab loodud kirje ID muutujasse `todoId`.
5. Kogus olevad kontrollid võrdlevad HTTP olekukoode ja kontrollivad muutmist ning kustutamist.

Päringuid saab teha ka failiga `TodoApi.http`. Postmani enda kasutajaliidese läbimine jääb õppijale; hoidla automaatkontroll kasutab samu HTTP-pöörduspunkte.

| Meetod | Aadress | Edukas vastus |
| --- | --- | --- |
| GET | `/api/todoitems` | 200, kõik ülesanded |
| GET | `/api/todoitems/{id}` | 200, üks ülesanne |
| POST | `/api/todoitems` | 201, loodud kirje ja Location päis |
| PUT | `/api/todoitems/{id}` | 204 |
| DELETE | `/api/todoitems/{id}` | 204 |

Puuduv kirje annab 404. Sobimatu sisend ja PUT-päringu erinevad ID-d annavad 400.
`Name` on kohustuslik ja kuni 200 märki. API kasutab DTO-d: mudeli `Secret` välja ei tagastata ega võeta kliendilt vastu. POST ignoreerib kliendi antud ID-d ja loob selle serveris.

Andmed on juhendi kohaselt EF Core InMemory andmebaasis ning kaovad rakenduse sulgemisel. Tegemist on kohaliku õppeprojektiga.
