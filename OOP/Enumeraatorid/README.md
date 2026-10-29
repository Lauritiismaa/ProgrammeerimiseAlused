# OOP – Enumeraatorid

**Õpilane:** Lauri Tiismaa

Need kolm C# harjutust vastavad vestluses antud ülesannete tekstile.

| Harjutus | Lahendus |
| --- | --- |
| 1. `Nadalapaev` | 7 nädalapäeva, väärtused 1–7, ühe päeva nime ja `(int)`-teisendusega arvu kuvamine |
| 2. `Kategooria` ja `Toode` | Enum `Toit`, `Jook`, `Majapidamine`; kolm toodet kategooriatega |
| 3. `TellimuseStaatus` ja `Tellimus` | Enum väärtustega 0–3, staatusomadus ja `Jargmine()` |

## Failid

- `Nadalapaev.cs` – nädalapäevade enumeraator
- `Kategooria.cs` ja `Toode.cs` – toodete kategooriad ning klass
- `TellimuseStaatus.cs` ja `Tellimus.cs` – tellimuse olekud ja edasiliikumine
- `Program.cs` – kõigi kolme harjutuse näited
- `Kontrollid.cs` – automaatsed kontrollid
- `Enumeraatorid.csproj` – .NET 8 konsooliprojekt

## Käivitamine

Vajalik on .NET 8 SDK. Hoidla juurkaustast:

```bash
dotnet run --project OOP/Enumeraatorid/Enumeraatorid.csproj
```

Kontrollide käivitamiseks:

```bash
dotnet run --project OOP/Enumeraatorid/Enumeraatorid.csproj -- --test
```

`Tellimus.Jargmine()` ei lase staatusel minna kaugemale kui `KohaleToimetatud`: viimasel olekul jääb olek samaks ja selle nimi trükitakse uuesti.

**Märkus:** lähtekoodile lisatud kontrollid, kuid töövahendite keskkonnas puudub .NET SDK, mistõttu neid ei saanud siin kompileerimisega kontrollida.
