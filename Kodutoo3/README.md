# 3. kodutöö – Adapter ja logimisklassid

**Õpilane:** Lauri Tiismaa

**Ülesanne:** https://gunnarpeipman.com/kool/programmeerimise-alused/kodutoo-3/

## Ülesande täitmine

1. Eraldi .NET 8 käsurearakendus, milles on BaseLogger, DebugLogger ja ConsoleLogger.
2. Kõigil loggeritel on Info(string message), Error(string message), Debug(string message) ja Warning(string message).
3. Program.cs loob BaseLogger[] massiivi. Esimene element on NullLoggerAdapter, seejärel DebugLogger ja ConsoleLogger.
4. For/foreach-tsükkel väljastab enne logimismeetodite kutsumist Console.WriteLine(logger.ToString()).
5. ConsoleLogger kirjutab konsooli; DebugLogger Visual Studio **Output > Debug** aknasse; NullLogger ei kirjuta midagi.
6. NullLogger.cs on esitatud ülesandes antud kujul ning seda pole muudetud.
7. NullLoggerAdapter pärib BaseLogger ja suunab Debug, Info, Warning, Error vastavalt WriteDebug, WriteInfo, WriteWarning, WriteError meetoditesse.
8. Kontrollid.cs sisaldab sisemisi kontrolle. DISAINIMUSTRID.md selgitab Adapterit ja muid disainimustreid koos näidetega.

**Täpsustus:** selle hoidla senises OOP/Parilus kaustas olid lemmikloomade klassid, mitte õpetaja loggerid. Seega on BaseLogger, DebugLogger ja ConsoleLogger selle ülesande jaoks loodud juhendi nõuete järgi; õpetaja originaalsete klasside täpset lähtekoodi ei olnud saadaval.

## Käivitamine

Nõutav on .NET 8 SDK. Hoidla juurkaustast:

    dotnet run --project Kodutoo3/Kodutoo3.csproj

Sisemised kontrollid:

    dotnet run --project Kodutoo3/Kodutoo3.csproj -- --test

## Visual Studio debugger (punkt 11)

1. Ava Visual Studios Kodutoo3/Kodutoo3.csproj ning vali **Debug** konfiguratsioon.
2. Ava NullLogger.cs ja aseta F9-ga murdepunktid WriteDebug, WriteInfo, WriteWarning ja WriteError meetoditele.
3. Tühjade üherealiste meetodite puhul võib murdepunktide kinnitamine oleneda kompilaatori optimeerimisest. Vajadusel aseta murdepunktid NullLoggerAdapter.cs vastavatele delegatsiooniridadele ja kasuta F11 (Step Into).
4. Käivita programm F5-ga. Kontrolli, et adapteri kaudu jõutakse kõigi nelja NullLoggeri meetodini.
5. Ava **View > Output** ja vali **Debug**. DebugLogger kirjutab sinna; ConsoleLogger kuvab teated konsoolis.
6. NullLogger ise ei väljasta midagi – see on selle klassi eesmärk ja ei tähenda, et meetodid jäid kutsumata.

## Adapteri osad

- Client: Program.cs kasutab kõigi loggerite puhul BaseLoggerit.
- Target: BaseLogger annab ühise Debug/Info/Warning/Error API.
- Adaptee: NullLogger pakub ainult WriteDebug/WriteInfo/WriteWarning/WriteError meetodeid.
- Adapter: NullLoggerAdapter sisaldab NullLogger objekti ning teisendab meetodikutsed.

Tänu adapterile saab muutmata NullLoggerit hoida koos teiste loggeritega samas BaseLogger massiivis.

## Materjalid

- [Refactoring.Guru: Adapter C#](https://refactoring.guru/design-patterns/adapter/csharp/example)
- [Dofactory: Adapter C#](https://www.dofactory.com/net/adapter-design-pattern)

**Kontrollimise seis:** lähtekood ja kontrollid on olemas, kuid tegelikku .NET kompileerimist ja Visual Studio silumiskontrolli tuleb teha arvutis, kus vastavad tööriistad on paigaldatud.
