using System.Threading;

namespace OOP.Klassid;

// Harjutus 5: sündmus käivitub pärast etteantud aja möödumist.
public class Taimer
{
    public event Action? AegTais;

    public void Alusta(int sekundid)
    {
        if (sekundid < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sekundid),
                "Sekundite arv ei tohi olla negatiivne.");
        }

        Thread.Sleep(TimeSpan.FromSeconds(sekundid));
        AegTais?.Invoke();
    }
}
