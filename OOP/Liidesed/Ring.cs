namespace ProgrammeerimiseAlused.OOP.Liidesed;

// Harjutus 1: Ring rakendab mõlemat IKujund meetodit.
public class Ring : IKujund
{
    public double Raadius { get; }

    public Ring(double raadius)
    {
        if (raadius <= 0 || double.IsNaN(raadius) || double.IsInfinity(raadius))
            throw new ArgumentOutOfRangeException(nameof(raadius),
                "Raadius peab olema positiivne lõplik arv.");

        Raadius = raadius;
    }

    public double Pindala()
    {
        return Math.PI * Raadius * Raadius;
    }

    public double Umbermoot()
    {
        return 2 * Math.PI * Raadius;
    }
}
