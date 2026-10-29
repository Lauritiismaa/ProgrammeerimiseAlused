namespace ProgrammeerimiseAlused.OOP.Parilus;

// Harjutused 1 ja 3: pärimine, abstraktse omaduse ja virtuaalse meetodi asendamine.
public class Kass : Lemmikloom
{
    public Kass(string nimi, int vanus) : base(nimi, vanus)
    {
    }

    public override string Liik => "Kass";

    public override void Haalitse()
    {
        Console.WriteLine("Mjäu!");
    }
}
