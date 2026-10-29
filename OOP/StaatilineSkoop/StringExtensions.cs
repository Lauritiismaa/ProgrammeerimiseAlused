namespace ProgrammeerimiseAlused.OOP.StaatilineSkoop;

// Harjutus 3: laiendusmeetod käib staatilisse klassi.
// Esimese parameetri "this string s" tõttu saab seda kutsuda tekst.LoendaSonad().
public static class StringExtensions
{
    public static int LoendaSonad(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        // Ühe või mitme tühikuga eraldatud sõnad; tühjad osad jäetakse arvestamata.
        return s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
