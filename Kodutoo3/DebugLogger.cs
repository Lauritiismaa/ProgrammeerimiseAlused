using System.Diagnostics;

namespace Kodutoo3;

// Kirjutab Visual Studio Output > Debug aknasse (Debug-konfiguratsioonis).
public sealed class DebugLogger : BaseLogger
{
    public override void Info(string message) => System.Diagnostics.Debug.WriteLine($"[INFO] {message}");
    public override void Error(string message) => System.Diagnostics.Debug.WriteLine($"[ERROR] {message}");
    public override void Debug(string message) => System.Diagnostics.Debug.WriteLine($"[DEBUG] {message}");
    public override void Warning(string message) => System.Diagnostics.Debug.WriteLine($"[WARNING] {message}");
}
