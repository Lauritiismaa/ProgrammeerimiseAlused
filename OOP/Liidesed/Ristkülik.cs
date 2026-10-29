namespace ProgrammeerimiseAlused.OOP.Liidesed;

// Harjutused 1 ja 4: üks klass võib rakendada mitut liidest.
// C# klass saab pärida ainult ühest baasklassist, kuid liidesed ei anna
// pärivat baasklassi ega konkureerivat isendi olekut. Seetõttu saab üks
// klass täita korraga mitut erinevat lepingut (IKujund ja IVarv).
public class Ristkülik : IKujund, IVarv
{
    public double Pikkus { get; }
    public double Laius { get; }

    // IVarv nõuab arvulise tunnuse esitamist.
    public int KulgedeArv => 4;

    public Ristkülik(double pikkus, double laius)
    {
        if (pikkus <= 0 || double.IsNaN(pikkus) || double.IsInfinity(pikkus))
            throw new ArgumentOutOfRangeException(nameof(pikkus),
                "Pikkus peab olema positiivne lõplik arv.");

        if (laius <= 0 || double.IsNaN(laius) || double.IsInfinity(laius))
            throw new ArgumentOutOfRangeException(nameof(laius),
                "Laius peab olema positiivne lõplik arv.");

        Pikkus = pikkus;
        Laius = laius;
    }

    public double Pindala()
    {
        return Pikkus * Laius;
    }

    public double Umbermoot()
    {
        return 2 * (Pikkus + Laius);
    }
}
