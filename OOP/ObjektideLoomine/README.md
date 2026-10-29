# OOP – Objektide loomine (4 harjutust)

**Õpilane:** Lauri Tiismaa

**Ülesannete allikas:** [Programmeerimise alused – objektide loomine](https://gunnarpeipman.com/kool/programmeerimise-alused/oop/objektide-loomine/#viited)

Selle peatüki neli ülesannet on lahendatud kasutaja edastatud täpse harjutusteksti järgi.

| Harjutus | Lahendus |
| --- | --- |
| 1. Auto kolme parameetriga konstruktor | `Auto.cs`, `Program.cs`: kaks eri autot ja nende andmete väljastamine |
| 2. Auto parameetriteta konstruktor | `Auto.cs`, `Program.cs`: objekti initsialiseerija ja kolme parameetriga konstruktor |
| 3. Raamat kahe konstruktoriga | `Raamat.cs`: `this(pealkiri, autor, 0)` konstruktorite ahel |
| 4. Toode vaikehinnaga | `Toode.cs`: ainult nime andmisel on `Hind = 0` |

`Program.cs` demonstreerib järgemööda kõiki nelja harjutust. `Kontrollid.cs` sisaldab lisakontrolle.

## Käivitamine

Vajalik on **.NET 8 SDK**. Hoidla juurkaustas käivita:

```bash
dotnet run --project OOP/ObjektideLoomine/ObjektideLoomine.csproj
```

Kontrollide käivitamiseks:

```bash
dotnet run --project OOP/ObjektideLoomine/ObjektideLoomine.csproj -- --test
```

**Märkus:** `Raamat` klassis tähistab aasta `0` määramata ilmumisaastat.
`Toode.Hind` on `decimal`, mis sobib rahasummade esitamiseks.

Failid on koostatud C#/.NET 8 süntaksi järgi; enne esitamist käivita projekt oma arvutis, et kontrollida kompileerimist ja väljundit.
