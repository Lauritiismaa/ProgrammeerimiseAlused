# 3. kodutöö – disainimustrite õppematerjal

**Õpilane:** Lauri Tiismaa

Allikad: [Refactoring.Guru](https://refactoring.guru/design-patterns) ja [Dofactory](https://www.dofactory.com/).
Konkreetsed C# näited: [Adapter (Refactoring.Guru)](https://refactoring.guru/design-patterns/adapter/csharp/example), [Adapter (Dofactory)](https://www.dofactory.com/net/adapter-design-pattern).

Disainimuster on korduva tarkvaraarhitektuurilise probleemi üldine lahenduspõhimõte. See ei ole valmis programm.

## Adapter (struktuurimuster)

**Miks vaja?** Programmi BaseLogger meetodid ja vana NullLoggeri Write*-meetodid ei sobi otse kokku. Ülesanne keelab vana klassi muutmise.

**Lahendus:** NullLoggerAdapter pärib BaseLogger ja hoiab muutmata NullLoggeri objekti. Debug kutsub WriteDebug, Info kutsub WriteInfo, Warning kutsub WriteWarning ning Error kutsub WriteError. Tänu sellele ei pea Program.cs teadma NullLoggeri eri meetodinimedest.

Osalised: Client = Program.cs; Target = BaseLogger; Adapter = NullLoggerAdapter; Adaptee = NullLogger.

**Teine näide:** eri makseteenuste meetodid saab Adapteriga siduda ühe maksesaamise liidesega, muutmata võõrast teeki.

## Strategy (käitumismuster)

**Miks vaja?** Eri klientide hinnaarvutuse pikk if/else võib kiiresti muutuda keeruliseks.

**Lahendus:** ühine IHinnaArvutus liides meetodiga Arvuta(decimal hind), mille eri teostused (Tavahind ja Soodushind) arvutavad hindu erinevalt. Ostukorv saab strateegiat vahetada.

**Harjutus:** rakenda täishind ja 10% allahindlus ning kontrolli 100 € ostu tulemust (100 € vs 90 €).

## Factory Method (loomismuster)

**Miks vaja?** Kliendikood ei peaks sõltuma iga teavitaja täpsest klassinimest.

**Lahendus:** loojate klassihierarhia määrab tehase meetodi, mille eri alamklassid loovad näiteks EmailTeavitaja või SmsTeavitaja. Kliendikood kasutab ühist teavitusliidest.

**Harjutus:** lisa kolmas teavitusviis nii, et kliendikoodis ei tuleks tüübi järgi if/else valikuid lisada.

## Observer (käitumismuster)

**Miks vaja?** Tellimuse staatuse muutusest peavad teada saama mitmed sõltumatud osad.

**Lahendus:** tellimus avaldab C# sündmuse StaatusMuutus; nii kasutajaliides kui ka teavitaja saavad selle sündmusega liituda.

**Harjutus:** lisa tellimusele sündmus ning registreeri kaks kuulajat. Kontrolli, et mõlemad reageerivad staatuse muutusele.

## Adapter või Decorator?

Adapter muudab ühe API teisega ühilduvaks. Decorator täiendab objekti käitumist üldjuhul sama liidese kaudu. Adapter sobib olemasoleva ühildumatu teegi liitmiseks; seda pole vaja kasutada, kui ühise liidese saab ohutult otse klassidele anda.

**Õppimise piir:** see dokument selgitab nelja mustrit ja pakub õppeharjutusi, kuid ei väida, et kõigi disainimustrite näited kummalgi veebilehel oleks läbi tehtud. Kodutöö praktiline C# programm teostab Adapteri.
