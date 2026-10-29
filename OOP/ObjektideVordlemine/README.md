# OOP – Objektide võrdlemine (4 harjutust)

**Õpilane:** Lauri Tiismaa

Lahendatud nelja harjutuse täpne tekst on antud vestluses. Kõik harjutused kasutavad sama `Toode` klassi, mida täiendatakse järjest.

| Harjutus | Teostus |
| --- | --- |
| 1. `Equals()` | `Toode.Equals()` võrdleb ainult `Kood` väärtust, ka eraldi isendite puhul |
| 2. `==` ja `!=` | Operaatorid kasutavad sama võrdsusloogikat ja arvestavad `null`-iga |
| 3. `GetHashCode()` | Sama koodiga toodetel on sama räsikood |
| 4. `List<Toode>.Contains()` | Eri isend samasuguse koodiga leitakse loendist |

## Käivitamine

Vajalik on .NET 8 SDK. Käivita hoidla juurkaustast:

```bash
dotnet run --project OOP/ObjektideVordlemine/ObjektideVordlemine.csproj
```

Kontrollide käivitamine:

```bash
dotnet run --project OOP/ObjektideVordlemine/ObjektideVordlemine.csproj -- --test
```

## Miks `Contains()` leiab eraldi isendi?

`List<Toode>.Contains()` kasutab vaikimisi `EqualityComparer<Toode>.Default`-i. Klass rakendab `IEquatable<Toode>` liidest ja võrdleb tooteid nende `Kood` järgi. Seega on näiteks `new Toode("B200", "Uus nimi")` võrdne juba loendis oleva sama koodiga tootega, kuigi tegemist on erineva objektiga.

Koodi kommentaarid selgitavad sama loogikat ka `Program.cs`-is.

`Kood` on pärast konstrueerimist ainult loetav, et selle muutmine ei muudaks objektide võrdsust ega räsikoodi näiteks `HashSet`-is. Koodide võrdlus on tõstutundlik (`StringComparer.Ordinal`).

**Märkus:** projekt sisaldab automaatseid kontrolle, kuid töövahendite keskkonnas puudub .NET SDK ning neid ei saanud siin käivitada.
