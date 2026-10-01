# Filmide andmebaas

Lauri Tiismaa

ASP.NET Core MVC õppeprojekt Microsofti [MVC juhendisarja](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-10.0) teemade põhjal.

## Käivitamine

Vajalik: .NET 10 SDK. Hoidla juurkaustas:

```sh
dotnet run --project Tooleht2/Movies --launch-profile http
```

Ava http://localhost:5101/Movies . Esimesel käivitamisel rakendatakse EF Core migratsioon ja lisatakse neli näidisfilmi. SQLite andmebaas `movies.db` luuakse projekti kausta ning seda ei laadita Giti.

Visual Studios ava `Movies.csproj` ja käivita profiil `http`.
HTTPS-i proovimiseks usalda kohalikku arendussertifikaati käsuga `dotnet dev-certs https --trust` ja vali profiil `https` (port 7101).

## Funktsioonid

- Filmide nimekiri ja üksikasjad.
- Filmi lisamine, muutmine ning kinnitusega kustutamine.
- Pealkirja otsing ja žanri filter, ka koos kasutades.
- Pealkiri, kuupäev, žanr, hind ja vanusepiirang (`Rating`).
- Serveri- ja kliendipoolne sisendi valideerimine.
- EF Core, SQLite, algandmed ja migratsioon.
- Juhendi alguse `HelloWorld` kontroller: `/HelloWorld/Welcome?name=Lauri&numTimes=3`.

Kood on juhendi teemade iseseisev teostus eestikeelse kasutajaliidesega. SQLite valik vastab juhendi platvormiülesele variandile; SQL Server LocalDB-d ei ole vaja. Vanusepiirang on tekst (näiteks `G` või `PG-13`), mitte arvuline hinne. Hind peab olema 1–100; sisesta kümnendkohad punktiga, näiteks `7.99`. Žanr algab suure tähega ja toetab ka eesti tähti.

## Koodi lugemine

1. `Models/Movie.cs` – andmed ja valideerimisreeglid.
2. `Data/MvcMovieContext.cs` – andmebaasikontekst.
3. `Controllers/MoviesController.cs` – päringud ja CRUD-tegevused.
4. `Views/Movies` – Razor-vaated.
5. `Program.cs` – teenused, migratsioon ja marsruudid.

Kui muudad mudelit, loo uus migratsioon (`dotnet ef migrations add MuudatuseNimi --project Tooleht2/Movies`). Selleks on vaja .NET 10-ga sobivat `dotnet-ef` tööriista. Käivitamisel rakendatakse lisatud migratsioonid automaatselt.
