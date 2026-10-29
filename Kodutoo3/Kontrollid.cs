namespace Kodutoo3;

// Käivitamine: dotnet run --project Kodutoo3/Kodutoo3.csproj -- --test
public static class Kontrollid
{
    public static void Käivita()
    {
        // Loggerid töötavad ühise BaseLogger tüübi kaudu.
        var nullLogger = new NullLogger();
        BaseLogger[] loggerid =
        {
            new NullLoggerAdapter(nullLogger),
            new DebugLogger(),
            new ConsoleLogger()
        };

        Nõua(loggerid.Length == 3, "Kolm loggerit");
        Nõua(loggerid[0] is NullLoggerAdapter, "Adapter on loendis esimene");
        Nõua(loggerid[1].ToString() == "DebugLogger", "DebugLoggeri tüübinimi");
        Nõua(loggerid[2].ToString() == "ConsoleLogger", "ConsoleLoggeri tüübinimi");

        // ConsoleLogger väljastab kõik neli erinevat logitaset.
        using var output = new StringWriter();
        BaseLogger konsool = new ConsoleLogger(output);
        konsool.Debug("silumine");
        konsool.Info("info");
        konsool.Warning("hoiatus");
        konsool.Error("viga");
        string[] read = output.ToString().Split(
            '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        Nõua(read.SequenceEqual(new[]
        {
            "[DEBUG] silumine", "[INFO] info", "[WARNING] hoiatus", "[ERROR] viga"
        }), "ConsoleLoggeri nelja taseme väljund");

        // NullLogger peab vaikima; adapter ei kirjuta ka ise midagi.
        // Tegelikku Write*-meetodite läbimist näeb Visual Studio breakpointidega.
        TextWriter algneVäljund = Console.Out;
        using var nullOutput = new StringWriter();
        try
        {
            Console.SetOut(nullOutput);
            loggerid[0].Debug("silumine");
            loggerid[0].Info("info");
            loggerid[0].Warning("hoiatus");
            loggerid[0].Error("viga");
        }
        finally
        {
            Console.SetOut(algneVäljund);
        }
        Nõua(nullOutput.ToString().Length == 0, "NullLoggeri vaikne väljund");

        // DebugLoggeri meetodite väljakutsed ei vaja eraldi objekti tüüpi.
        // Debug.WriteLine väljundit saab näha Visual Studio Output > Debug aknas.
        loggerid[1].Debug("kontroll");
        loggerid[1].Info("kontroll");
        loggerid[1].Warning("kontroll");
        loggerid[1].Error("kontroll");

        Console.WriteLine("Kõik kodutöö sisemised kontrollid läbitud.");
    }

    private static void Nõua(bool tingimus, string kirjeldus)
    {
        if (!tingimus)
            throw new Exception("Kontroll ebaõnnestus: " + kirjeldus);
    }
}
