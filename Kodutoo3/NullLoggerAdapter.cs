namespace Kodutoo3;

// Adapteri disainimuster:
// Target = BaseLogger; Adaptee = muutmata NullLogger; Adapter = see klass.
// Kompositsioon võimaldab kasutada olemasolevat NullLoggerit BaseLoggeri kaudu.
public sealed class NullLoggerAdapter : BaseLogger
{
    private readonly global::NullLogger _nullLogger;

    public NullLoggerAdapter(global::NullLogger nullLogger)
    {
        _nullLogger = nullLogger ?? throw new ArgumentNullException(nameof(nullLogger));
    }

    // Adapter teisendab BaseLoggeri meetodikutsed NullLoggeri Write*-meetoditeks.
    public override void Info(string message) => _nullLogger.WriteInfo(message);
    public override void Error(string message) => _nullLogger.WriteError(message);
    public override void Debug(string message) => _nullLogger.WriteDebug(message);
    public override void Warning(string message) => _nullLogger.WriteWarning(message);
}
