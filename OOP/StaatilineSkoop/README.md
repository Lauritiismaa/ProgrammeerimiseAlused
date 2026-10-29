# OOP – Staatiline skoop (4 harjutust)

**Õpilane:** Lauri Tiismaa

Lahendused põhinevad vestluses antud neljal C# harjutusel.

| Harjutus | Lahendus |
| --- | --- |
| 1. `Loendur` | `static int Kokku` ning konstruktor, mis suurendab seda; kolm objekti |
| 2. `Matemaatika` | Staatiline klass meetoditega `Ruut(int)` ja `Kuup(int)` |
| 3. `StringExtensions` | Staatiline laiendusmeetod `LoendaSonad(this string s)`, mis loendab tühikutega eraldatud sõnad |
| 4. `Konverter` | Staatiline konstruktor määrab `VaikeYhik = "km"` ja kuvab käivitumise teate |

## Käivitamine

Vajalik on **.NET 8 SDK**. Hoidla juurkaustast:

```bash
dotnet run --project OOP/StaatilineSkoop/StaatilineSkoop.csproj
```

Kontrollide käivitamiseks:

```bash
dotnet run --project OOP/StaatilineSkoop/StaatilineSkoop.csproj -- --test
```

## Selgitused

- `Loendur.Kokku` on klassi ühine omadus. Iga `new Loendur()` suurendab seda.
- `Matemaatika.Ruut(4)` ja `Matemaatika.Kuup(4)` kutsutakse ilma objekti loomata.
- Laiendusmeetodi kasutus on näiteks `"Kaks sõna".LoendaSonad()`. Eraldajaks on tühik; järjestikused tühikud ei tekita lisasõnu.
- Staatiline konstruktor `static Konverter()` käivitub automaatselt ainult üks kord, kui tüüp esimest korda kasutusele võetakse. `Program.cs` väljastab teate enne esimest `Konverter.VaikeYhik` lugemist ning näitab seejärel, et teisel lugemisel konstruktor enam ei käivitu.

Lisatud on eraldi `Kontrollid.cs`, mis kontrollib põhilised tulemused ja staatilise konstruktori ühekordse käivitumise.

**Märkus:** lähtekoodid on kirjutatud .NET 8 jaoks, kuid siin polnud .NET SDK-d saadaval, mistõttu kompileerimist ja kontrollprogrammi käivitamist ei olnud võimalik kohapeal kinnitada.
