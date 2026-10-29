namespace Kodutoo3;

// Kirjutab kõik neli logitaset käsureale.
public sealed class ConsoleLogger : BaseLogger
{
    private readonly TextWriter _output;

    // Võimalus suunata väljund kontrollides StringWriter-isse.
    public ConsoleLogger(TextWriter? output = null)
    {
        _output = output ?? Console.Out;
    }

    public override void Info(string message) => _output.WriteLine($"[INFO] {message}");
    public override void Error(string message) => _output.WriteLine($"[ERROR] {message}");
    public override void Debug(string message) => _output.WriteLine($"[DEBUG] {message}");
    public override void Warning(string message) => _output.WriteLine($"[WARNING] {message}");
}
