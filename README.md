# ProgrammeerimiseAlused

Lauri Tiismaa

Kodutööd ja programmeerimisharjutused. Lahendused sisaldavad käivitamisjuhiseid ja selgitusi, mille abil kood ise läbi töötada.

## Projektid

| Ülesanne | Asukoht | Sisu |
| --- | --- | --- |
| 1. kodutöö | [ArvamisMang](Kodutoo1/ArvamisMang) | Arvu äraarvamine, suurem/väiksem/õige, vigase sisendi kontroll |
| Esimene tund (12.09) | [TereMaailm ja profiil](12-09-harjutused/README.md) | Nime küsimine, kaks committi, profiili README ettevalmistus |
| Git | [Git-harjutused](Git-harjutused/README.md) | Harud, tegelik ühendamiskonflikt ja lahendus, käsujuhend |
| Tööleht 2: MVC | [Movies](Tooleht2/Movies/README.md) | Filmid, SQLite, CRUD, otsing, valideerimine |
| Tööleht 2: Web API | [TodoApi](Tooleht2/TodoApi/README.md) | Kontrolleripõhine CRUD API, DTO ja Postmani kogu |

## Käivitamine

Kõik projektid kasutavad .NET 10 SDK-d, kooskõlas õpetaja töölehe praeguste Microsofti juhenditega. Ka varasem arvamismäng on ühtlustatud .NET 10 peale.
Ava Visual Studios `ProgrammeerimiseAlused.sln` või kasuta terminali:

```sh
dotnet build ProgrammeerimiseAlused.sln
dotnet run --project Kodutoo1/ArvamisMang
dotnet run --project 12-09-harjutused/TereMaailm
```

Käivita veebiprojektid eraldi terminalides:

```sh
dotnet run --project Tooleht2/Movies --launch-profile http
dotnet run --project Tooleht2/TodoApi --launch-profile http
```

- Filmid: http://localhost:5101/Movies
- API: http://localhost:5102/api/todoitems
- Postmani importfail: `Tooleht2/TodoApi/TodoApi.postman_collection.json`

## Kontrollimine

[Kontrollide kirjeldus ja tulemused](Kontrollid/README.md).
Veebikontrolli saab pärast kompileerimist korrata Python 3 abil:

```sh
python Kontrollid/smoke_test.py
```

See loob ajutise andmebaasi ja käivitab projektid portidel 15101 ning 15102. Igapäevase arenduse andmebaasi ei muudeta.

## GitHubis tehtud

- Profiili nimi ja lühitutvustus on lisatud.
- [Profiilihoidla Lauritiismaa](https://github.com/Lauritiismaa/Lauritiismaa) on loodud ja README avaldatud.
- Eraldi avalikud hoidlad koos koodi ja käivitamisjuhistega: [TereMaailm](https://github.com/Lauritiismaa/TereMaailm), [Movies](https://github.com/Lauritiismaa/Movies) ja [TodoApi](https://github.com/Lauritiismaa/TodoApi).
- TereMaailma ajaloos on eraldi commitid „Esimene commit” ja „Lisatud nime küsimine”.
- Õpetaja `gpeipman` kirjutamisõigus selles koolitööde hoidlas on kontrollitud.

## Veel isiklikult lõpetada

- Valida ja lisada GitHubi profiilipilt.
- Seadistada konto kahefaktoriline autentimine (2FA).
- Käivitada projektid enda Visual Studios, teha päringud Postmanis ning töötada kood läbi.

Neid isiklikke samme ei loeta üksnes lähtekoodi olemasolu põhjal tehtuks.
