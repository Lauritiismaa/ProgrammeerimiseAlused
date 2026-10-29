namespace Kodutoo3;

// Kõigi loggerite ühine baasklass.
// Info ja Error on põhilised logimismeetodid;
// Debug ja Warning on kodutöö juhendi järgi lisatud meetodid.
public abstract class BaseLogger
{
    public abstract void Info(string message);
    public abstract void Error(string message);
    public abstract void Debug(string message);
    public abstract void Warning(string message);

    // Program.cs kasutab nõutud viisil Console.WriteLine(logger.ToString()).
    public override string ToString() => GetType().Name;
}
