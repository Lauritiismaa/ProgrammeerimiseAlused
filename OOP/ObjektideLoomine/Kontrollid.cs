using ProgrammeerimiseAlused.OOP.ObjektideLoomine;

public static class Kontrollid
{
    public static void Käivita()
    {
        // 1. Kaks eri autot kolme parameetriga konstruktoriga.
        var auto1 = new Auto("Toyota", "Corolla", 2020);
        var auto2 = new Auto("Volvo", "V60", 2022);
        Kontrolli(auto1.Mark == "Toyota" && auto1.Mudel == "Corolla"
                  && auto1.Aasta == 2020, "Harjutus 1, esimene auto");
        Kontrolli(auto2.Mark == "Volvo" && auto2.Mudel == "V60"
                  && auto2.Aasta == 2022, "Harjutus 1, teine auto");

        // 2. Parameetriteta konstruktor ja objekti initsialiseerija.
        var auto3 = new Auto { Mark = "Škoda", Mudel = "Octavia", Aasta = 2019 };
        var auto4 = new Auto("Audi", "A4", 2021);
        Kontrolli(auto3.Mark == "Škoda" && auto3.Aasta == 2019,
                  "Harjutus 2, objekti initsialiseerija");
        Kontrolli(auto4.Mudel == "A4" && auto4.Aasta == 2021,
                  "Harjutus 2, parameetritega konstruktor");

        // 3. Ülekoormatud konstruktorid ja this(...).
        var raamat1 = new Raamat("Kevade", "Oskar Luts");
        var raamat2 = new Raamat("Tõde ja õigus", "A. H. Tammsaare", 1926);
        Kontrolli(raamat1.Pealkiri == "Kevade" && raamat1.Autor == "Oskar Luts"
                  && raamat1.Aasta == 0, "Harjutus 3, kahe parameetriga konstruktor");
        Kontrolli(raamat2.Aasta == 1926 && raamat2.Pealkiri == "Tõde ja õigus",
                  "Harjutus 3, kolme parameetriga konstruktor");

        // 4. Kaks eri konstruktorit, hinnaks vaikimisi null.
        var toode1 = new Toode("Pliiats");
        var toode2 = new Toode("Vihik", 2.50m);
        Kontrolli(toode1.Nimi == "Pliiats" && toode1.Hind == 0m,
                  "Harjutus 4, vaikehind");
        Kontrolli(toode2.Nimi == "Vihik" && toode2.Hind == 2.50m,
                  "Harjutus 4, määratud hind");

        Console.WriteLine("Kõik nelja harjutuse kontrollid läbitud.");
    }

    private static void Kontrolli(bool tingimus, string harjutus)
    {
        if (!tingimus)
        {
            throw new Exception("Kontroll ebaõnnestus: " + harjutus);
        }
    }
}
