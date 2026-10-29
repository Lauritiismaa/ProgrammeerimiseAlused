namespace ProgrammeerimiseAlused.OOP.Parilus;

// Harjutused 1, 3 ja 4: sealed takistab klassist Koer edasi pärimist.
public sealed class Koer : Lemmikloom
{
    public Koer(string nimi, int vanus) : base(nimi, vanus)
    {
    }

    public override string Liik => "Koer";

    public override void Haalitse()
    {
        Console.WriteLine("Auh-auh!");
    }
}
