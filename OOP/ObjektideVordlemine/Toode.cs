namespace ProgrammeerimiseAlused.OOP.ObjektideVordlemine;

/// <summary>
/// Kaks toodet on võrdsed, kui nende kood on sama.
/// Nimi ei mõjuta võrdsust.
/// </summary>
public sealed class Toode : IEquatable<Toode>
{
    // Kood on ainult loetav, et seda ei muudetaks näiteks HashSetis kasutamise ajal.
    public string Kood { get; }
    public string Nimi { get; set; }

    public Toode(string kood, string nimi)
    {
        if (string.IsNullOrWhiteSpace(kood))
            throw new ArgumentException("Toote kood peab olema määratud.", nameof(kood));

        Kood = kood;
        Nimi = nimi;
    }

    // Harjutus 1: Equals võrdleb Kood omadust, mitte objektide viiteid.
    public override bool Equals(object? obj) =>
        obj is Toode teine && Equals(teine);

    public bool Equals(Toode? teine) =>
        teine is not null && StringComparer.Ordinal.Equals(Kood, teine.Kood);

    // Harjutus 2: mõlemad operaatorid kasutavad sama võrdsuse loogikat.
    public static bool operator ==(Toode? vasak, Toode? parem)
    {
        if (ReferenceEquals(vasak, parem))
            return true; // Sama isend või mõlemad null.

        if (vasak is null || parem is null)
            return false;

        return vasak.Equals(parem);
    }

    public static bool operator !=(Toode? vasak, Toode? parem) =>
        !(vasak == parem);

    // Harjutus 3: samad koodid annavad samad räsikoodid.
    // Kasutame sama StringComparer.Ordinal võrdlusreeglit, mis Equals-is.
    public override int GetHashCode() =>
        StringComparer.Ordinal.GetHashCode(Kood);
}
