namespace ProgrammeerimiseAlused.OOP.Enumeraatorid;

// Harjutus 2: igal tootel on nimi, hind ja kategooria.
public class Toode
{
    public string Nimi { get; set; }
    public decimal Hind { get; set; }
    public Kategooria Kategooria { get; set; }

    public Toode(string nimi, decimal hind, Kategooria kategooria)
    {
        Nimi = nimi;
        Hind = hind;
        Kategooria = kategooria;
    }
}
