# OOP – Vead (5 harjutust)

**Õpilane:** Lauri Tiismaa

Harjutused on lahendatud vestluses antud ülesandetekstide põhjal C# ja .NET 8 abil.

| Harjutus | Lahendus |
| --- | --- |
| 1. `Jaga(int x, int y)` | `Harjutused.cs`: kui `y == 0`, viskab `DivideByZeroException`; `Program.cs` püüab erindi `try-catch` plokis |
| 2. `Toode.Hind` | `Toode.cs`: negatiivne hind viskab `ArgumentOutOfRangeException`; programm demonstreerib õiget ja valet hinda |
| 3. `andmed.txt` | `FailiLugeja.cs`: `FileNotFoundException` eraldi käsitlemine ja alati käivituv `finally` tekstiga `Töö lõpetatud` |
| 4. `LoePikkus(string s)` | Algne `NullReferenceException` pakitakse `ApplicationException` sisse koos `InnerException`-iga; kuvatakse stack trace ja algne põhjus |
| 5. `Stopwatch` | `JoudlusVordlus.cs`: 10 000 elemendiga loend, `try-catch` vs nullikontroll; sama arvutus, soojendus ja mõõtmine |

## Käivitamine

Vajalik on **.NET 8 SDK**. Käivita hoidla juurkaustast:

```bash
dotnet run --project OOP/Vead/Vead.csproj
```

Automaatsete kontrollide käivitamiseks:

```bash
dotnet run --project OOP/Vead/Vead.csproj -- --test
```

Fail `andmed.txt` kopeeritakse automaatselt programmi väljundkausta, et lugemine õnnestuks sõltumata töökataloogist. Programmis proovitakse ka teadlikult puuduvat faili, et kuvada eraldi `FileNotFoundException`-i käsitlemine.

## Harjutus 4 – vea algse põhjuse tuvastamine

`LoePikkus(null!)` tekitab `NullReferenceException`-i, kui programm proovib lugeda `s.Length` väärtust. `catch` loob uue `ApplicationException`-i ja annab algse erindi teise argumendina edasi. `InnerException` säilitab algse tüübi, teate ja stack trace'i; `ex.ToString()` kuvab mõlema vea ahela.

## Harjutus 5 – tulemuste võrdlus

Mõlemas tsüklis töödeldakse samu **10 000 elementi**, millest iga kümnes on `null`. Esimene lähenemine lubab vigasel elemendil põhjustada erindi ja püüab selle kinni, teine kontrollib elementi enne kasutamist. Mõõtmist korratakse 15 korda ja enne mõõtmist tehakse soojendus. Võrreldavad kontrollsummad peavad olema võrdsed.

**Järeldus:** erindite loomine ja püüdmine on kulukas, seega on ette teada olevate puuduvate väärtuste korral tavaliselt mõistlikum kasutada eelnevat nullikontrolli. Stopwatch-i täpsed ajad sõltuvad masinast, JIT-ist ja muudest protsessidest; need on näidismõõtmised, mitte universaalsed kiirused.

**Märkus:** siin pole .NET SDK-d, mistõttu automaatseid kontrolle ei saanud keskkonnas käivitada. Kontrollimiseks kasuta ülaltoodud käske oma arvutis.
