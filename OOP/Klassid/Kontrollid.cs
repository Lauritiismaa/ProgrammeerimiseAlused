namespace OOP.Klassid;

// Käivita: dotnet run --project OOP/Klassid -- --test
public static class Kontrollid
{
    public static void Käivita()
    {
        var raamat = new Raamat
        {
            Pealkiri = "Kevade",
            Autor = "Oskar Luts",
            LehekülgedeArv = 300
        };
        Nõua(raamat.Pealkiri == "Kevade"
            && raamat.Autor == "Oskar Luts" && raamat.LehekülgedeArv == 300,
            "Raamat");

        var konto = new PangaKonto();
        Nõua(konto.Deposit(1500), "Positiivne sissemakse");
        Nõua(!konto.Deposit(-5), "Negatiivne sissemakse");
        Nõua(!konto.Withdraw(1001), "Üle MaxWithdraw väljamakse");
        Nõua(konto.Withdraw(500), "Lubatud väljamakse");
        Nõua(!konto.Withdraw(1001) && !konto.Withdraw(1100), "Väljamakse piirang");
        Nõua(konto.Withdraw(1000) && konto.Balance == 0, "Jääk ei lähe negatiivseks");
        Nõua(!konto.Withdraw(1), "Puuduv raha");
        Nõua(!konto.Deposit(double.NaN), "NaN sissemakse");

        var temperatuur = new Temperatuur { Celsius = 0 };
        Nõua(Math.Abs(temperatuur.Fahrenheit - 32) < 0.0001, "Fahrenheiti teisendus");
        temperatuur.Celsius = -273.15;
        Nõua(Math.Abs(temperatuur.Fahrenheit + 459.67) < 0.0001, "Absoluutne null");
        bool viganeTemperatuurKeelatud = false;
        try
        {
            temperatuur.Celsius = -273.16;
        }
        catch (ArgumentOutOfRangeException)
        {
            viganeTemperatuurKeelatud = true;
        }
        Nõua(viganeTemperatuurKeelatud, "Temperatuuri alumine piir");

        var kalkulaator = new Kalkulaator();
        Nõua(kalkulaator.Korruta(3, 4) == 12, "Kahe arvu korrutis");
        Nõua(kalkulaator.Korruta(2, 3, 4) == 24, "Kolme arvu korrutis");

        var taimer = new Taimer();
        bool aegTais = false;
        taimer.AegTais += () => aegTais = true;
        taimer.Alusta(0);
        Nõua(aegTais, "Taimeri sündmus");

        Console.WriteLine("Kõik klasside harjutuste kontrollid läbitud.");
    }

    private static void Nõua(bool tingimus, string nimetus)
    {
        if (!tingimus)
        {
            throw new Exception("Kontroll ebaõnnestus: " + nimetus);
        }
    }
}
