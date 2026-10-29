namespace ProgrammeerimiseAlused.OOP.Parilus;

// Harjutused 1 ja 3: ühised omadused, virtuaalne meetod ning abstraktne Liik.
public abstract class Lemmikloom
{
    public string Nimi { get; set; }
    public int Vanus { get; set; }

    protected Lemmikloom(string nimi, int vanus)
    {
        if (string.IsNullOrWhiteSpace(nimi))
            throw new ArgumentException("Lemmiklooma nimi ei tohi olla tühi.", nameof(nimi));
        if (vanus < 0)
            throw new ArgumentOutOfRangeException(nameof(vanus), "Vanus ei saa olla negatiivne.");

        Nimi = nimi;
        Vanus = vanus;
    }

    // Abstraktne omadus tuleb igas konkreetses pärivas klassis üle kirjutada.
    public abstract string Liik { get; }

    // Virtuaalset meetodit saab alamklassides override abil asendada.
    public virtual void Haalitse()
    {
        Console.WriteLine("Lemmikloom teeb häält.");
    }
}
