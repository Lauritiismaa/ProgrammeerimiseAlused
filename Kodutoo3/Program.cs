using Kodutoo3;

Console.OutputEncoding = System.Text.Encoding.UTF8;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("3. kodutöö – Adapteri disainimuster ja loggerid");
Console.WriteLine();

// NullLogger tuleb kõigepealt, kuid BaseLogger massiiv sisaldab ka teisi loggereid.
// NullLogger ise ei päri BaseLoggerit – seda võimaldab ainult adapter.
BaseLogger[] loggerid =
{
    new NullLoggerAdapter(new NullLogger()),
    new DebugLogger(),
    new ConsoleLogger()
};

foreach (BaseLogger logger in loggerid)
{
    // Ülesande punkt 4: kuvame tüübi ENNE iga loggeri meetodite väljakutsumist.
    Console.WriteLine(logger.ToString());

    logger.Debug("Rakenduse silumisteade.");
    logger.Info("Rakendus käivitus.");
    logger.Warning("Hoiatus: näidisandmed on kasutusel.");
    logger.Error("Näidisvea teade.");

    Console.WriteLine();
}

Console.WriteLine("ConsoleLogger kirjutas konsooli, DebugLogger Visual Studio Debug-väljundisse.");
Console.WriteLine("NullLogger ei kirjuta midagi. Kontrolli selle meetodikutsed debuggeris.");
