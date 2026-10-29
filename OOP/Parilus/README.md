# OOP – Pärilus

**Õpilane:** Lauri Tiismaa

Siin on neli päriluse harjutust C# keeles vastavalt ülesande sõnastusele.

| Harjutus | Lahendus |
| --- | --- |
| 1. Baasklass ja pärivad klassid | `Lemmikloom.cs`, `Koer.cs`, `Kass.cs` – virtuaalne `Haalitse()` ja `override` |
| 2. Baasklassi tüüpi massiiv | `Program.cs` – `Lemmikloom[]` ja `foreach` |
| 3. Abstraktne klass ja omadus | `Lemmikloom` on `abstract`; `Liik` on `abstract` ning alamklassid määravad väärtuse |
| 4. `sealed` klass ja kompilaatoriviga | `Koer` on `sealed`; `SealedNaide.cs` sisaldab tingimuslikku vigast pärimiskatset ja seletust |

## Miks koer ja kass häälitsevad erinevalt?

Meetod `Haalitse()` on baasklassis `virtual`. Iga alamklass määrab enda versiooni `override` abil. Kui muutuja tüüp on `Lemmikloom`, kasutab C# **polümorfismi**: käitusajal valitakse objekti tegeliku tüübi järgi `Koer.Haalitse()` või `Kass.Haalitse()`.

## Käivitamine

Nõutav on .NET 8 SDK. Hoidla juurkaustast:

```bash
dotnet run --project OOP/Parilus/Parilus.csproj
```

Lisatud kontrollide käivitamiseks:

```bash
dotnet run --project OOP/Parilus/Parilus.csproj -- --test
```

Harjutuse 4 **oodatava kompileerimisvea** kontrollimiseks:

```bash
dotnet build OOP/Parilus/Parilus.csproj -p:DefineConstants=SEALED_VEA_NAIDE
```

See aktiveerib failis `SealedNaide.cs` klassi `Taksi : Koer`. Oodatav on **CS0509** (`cannot derive from sealed type 'Koer'`), sest `Koer` on `sealed`. Ilma sümbolita `SEALED_VEA_NAIDE` saab projekt tavaliselt kompileeruda.

**Märkus:** failide loomise keskkonnas ei olnud .NET SDK-d, seega tegelikku kompileerimist ei saanud siin läbi viia.
