# OOP – Liidesed (4 harjutust)

**Õpilane:** Lauri Tiismaa

Lahendused põhinevad vestluses antud neljal harjutusel.

| Harjutus | Failid ja lahendus |
| --- | --- |
| 1. `IKujund`, `Ring`, `Ristkülik` | `IKujund.cs`, `Ring.cs`, `Ristkülik.cs`; pindala ja ümbermõõdu arvutamine |
| 2. `IKujund[]` massiiv | `Program.cs`; tsükkel kasutab sama liidese kaudu mõlema kujundi `Pindala()` meetodit |
| 3. `INime : IDisposable` | `INime.cs`, `NimegaEse.cs`; `Kirjelda()` ja `Dispose()` ning `using`-plokk |
| 4. Üks klass, kaks liidest | `Ristkülik : IKujund, IVarv`; `IVarv` tagastab külgede arvu |

## Miks on liides kasulik?

`IKujund` määrab ühtse lepingu kujundite pindala ja ümbermõõdu arvutamiseks.
`IKujund[]` saab sisaldada nii ringe kui ka ristkülikuid. Tsükkel kutsub
`Pindala()` välja sõltumata kujundi konkreetsest tüübist – iga klass annab
omaenda teostuse. Uute kujundite lisamine ei nõua sama tsükli muutmist.

## Miks saab rakendada mitut liidest?

C# lubab klassil pärida ühest baasklassist, kuid rakendada mitut liidest.
Liidesed on erinevad käitumislepingud, mille liikmed klass ise teostab.
Selles näites täidab `Ristkülik` korraga `IKujund` ja `IVarv`.
Seda selgitab kommentaar ka `Ristkülik.cs` failis.

## Käivitamine

Vajalik on .NET 8 SDK. Hoidla juurkaustast:

```bash
dotnet run --project OOP/Liidesed/Liidesed.csproj
```

Kontrollide käivitamine:

```bash
dotnet run --project OOP/Liidesed/Liidesed.csproj -- --test
```

**Märkus:** keskkonnas ei olnud .NET SDK-d, mistõttu projekti tegelik kompileerimine ja kontrollide käivitamine jäi kinnitamata.
