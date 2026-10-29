namespace ProgrammeerimiseAlused.OOP.Vead;

// Harjutus 2: Hind setteri kontroll ja ArgumentOutOfRangeException.
public class Toode
{
    private decimal _hind;

    public decimal Hind
    {
        get => _hind;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(Hind), value, "Hind ei tohi olla negatiivne.");

            _hind = value;
        }
    }

    public Toode(decimal hind)
    {
        Hind = hind;
    }
}
