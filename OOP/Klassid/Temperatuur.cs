namespace OOP.Klassid;

// Harjutus 3: setter kontrollib absoluutset nulli ja Fahrenheit arvutatakse.
public class Temperatuur
{
    private double _celsius;

    public double Celsius
    {
        get { return _celsius; }
        set
        {
            if (value < -273.15 || double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Temperatuur ei tohi olla alla -273,15 °C.");
            }

            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get { return Celsius * 9.0 / 5.0 + 32; }
    }
}
