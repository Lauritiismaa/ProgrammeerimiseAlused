namespace ProgrammeerimiseAlused.OOP.StaatilineSkoop;

// Harjutus 4: staatiline konstruktor käivitub automaatselt üks kord,
// enne tüübi esimest kasutamist. Staatilisel konstruktoril pole parameetreid.
public static class Konverter
{
    public static string VaikeYhik { get; private set; }

    static Konverter()
    {
        VaikeYhik = "km";
        Console.WriteLine("Konverteri staatiline konstruktor käivitus.");
    }
}
