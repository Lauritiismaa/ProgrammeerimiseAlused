# OOP – Klassid (harjutused 1–5)

Autor: Lauri Tiismaa

Õpetaja materjal: https://gunnarpeipman.com/kool/programmeerimise-alused/oop/klassid/

Selles kaustas on **Klassid** peatüki kõik viis harjutust C# keeles:

1. **Raamat** – omadused ja andmete kuvamine konsoolil.
2. **PangaKonto** – privaatne kontojääk, ainult loetav omadus `Balance`,
   `Deposit`, `Withdraw` ja konstant `MaxWithdraw = 1000`.
3. **Temperatuur** – absoluutse nulli kontroll ja ainult loetav `Fahrenheit`.
4. **Kalkulaator** – kahe ja kolme täisarvuga `Korruta`-meetodid.
5. **Taimer** – sündmus `AegTais` ja meetod `Alusta(int sekundid)`.

## Käivitamine

Eeldus: .NET 8 SDK.

Hoidla juurkaustast:

```bash
dotnet run --project OOP/Klassid/Klassid.csproj
```

Harjutuste sisemiste kontrollide käivitamiseks:

```bash
dotnet run --project OOP/Klassid/Klassid.csproj -- --test
```

**Märkus:** siin on lingitud *Klassid* peatüki viis harjutust.
OOP ülejäänud peatükid (objektide loomine, võrdlemine, pärilus, liidesed,
enumeraatorid, staatiline skoop, vead) ei kuulu nende viie harjutuse hulka.
