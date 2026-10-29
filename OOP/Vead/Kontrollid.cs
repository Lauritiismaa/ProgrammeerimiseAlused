using ProgrammeerimiseAlused.OOP.Vead;

public static class Kontrollid
{
    public static void Käivita()
    {
        // Harjutus 1.
        Kontrolli(Harjutused.Jaga(12, 3) == 4, "Jagamise tulemus");
        bool jagamiseViga = false;
        try { Harjutused.Jaga(10, 0); }
        catch (DivideByZeroException) { jagamiseViga = true; }
        Kontrolli(jagamiseViga, "DivideByZeroException");

        // Harjutus 2: ka pärast ebaõnnestunud setterit on vana väärtus alles.
        var toode = new Toode(5.75m);
        bool hinnaViga = false;
        try { toode.Hind = -1m; }
        catch (ArgumentOutOfRangeException) { hinnaViga = true; }
        Kontrolli(hinnaViga && toode.Hind == 5.75m, "Negatiivse hinna keeld");
        toode.Hind = 0m;
        Kontrolli(toode.Hind == 0m, "Nullhind on lubatud");

        // Harjutus 3: olemasolev fail ja puuduv fail; finally mõlemal juhul.
        string olemasolev = Path.Combine(AppContext.BaseDirectory, "andmed.txt");
        string puuduv = Path.Combine(
            AppContext.BaseDirectory, "kindlasti_puuduv_fail_987654321.txt");
        using var edukasValjund = new StringWriter();
        using var puuduvaValjund = new StringWriter();
        Kontrolli(FailiLugeja.LoeFail(olemasolev, edukasValjund), "Faili lugemine");
        Kontrolli(edukasValjund.ToString().Contains("Töö lõpetatud"), "Finally õnnestumisel");
        Kontrolli(!FailiLugeja.LoeFail(puuduv, puuduvaValjund), "Puuduva faili tuvastamine");
        Kontrolli(puuduvaValjund.ToString().Contains("Fail puudub."), "FileNotFoundException teade");
        Kontrolli(puuduvaValjund.ToString().Contains("Töö lõpetatud"), "Finally vea korral");

        // Harjutus 4: uus erind säilitab algse vea InnerException all.
        Kontrolli(Harjutused.LoePikkus("abc") == 3, "Teksti pikkus");
        bool algneVigaAlles = false;
        try { Harjutused.LoePikkus(null!); }
        catch (ApplicationException ex)
        {
            algneVigaAlles = ex.InnerException is NullReferenceException
                && ex.ToString().Contains("NullReferenceException")
                && ex.StackTrace is not null;
        }
        Kontrolli(algneVigaAlles, "ApplicationException ja algne stack trace");

        // Harjutus 5: mõõtmine tagastab mõõdetud ajad ja võrdsed arvutustulemused.
        var tulemus = JoudlusVordlus.Mooda();
        Kontrolli(tulemus.TryCatchMs >= 0 && tulemus.KontrollMs >= 0,
            "Stopwatch mõõtmised");
        Kontrolli(tulemus.Summa == 10_000L / 10 * 9 * 5 * 15,
            "Jõudlusvõrdluse kontrollsumma");

        Console.WriteLine("Kõik viie harjutuse kontrollid läbitud.");
    }

    private static void Kontrolli(bool tingimus, string nimetus)
    {
        if (!tingimus)
            throw new Exception("Kontroll ebaõnnestus: " + nimetus);
    }
}
