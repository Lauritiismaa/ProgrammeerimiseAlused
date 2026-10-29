namespace ProgrammeerimiseAlused.OOP.ObjektideLoomine;

public class Toode
{
    public string Nimi { get; set; }
    public decimal Hind { get; set; }

    // Harjutus 4: ainult nime andmisel on hind vaikimisi 0.
    public Toode(string nimi) : this(nimi, 0m)
    {
    }

    public Toode(string nimi, decimal hind)
    {
        Nimi = nimi;
        Hind = hind;
    }
}
