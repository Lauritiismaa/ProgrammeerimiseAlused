using ProgrammeerimiseAlused.OOP.Enumeraatorid;

public static class Kontrollid
{
    public static void Käivita()
    {
        // Harjutus 1: nädalapäevade numbrid on järjest 1–7.
        var paevad = Enum.GetValues<Nadalapaev>();
        Kontrolli(paevad.Length == 7, "Seitse nädalapäeva");
        for (int i = 0; i < paevad.Length; i++)
            Kontrolli((int)paevad[i] == i + 1, "Nädalapäeva number " + (i + 1));
        Kontrolli(Nadalapaev.Pühapäev.ToString() == "Pühapäev", "Päeva nimetus");

        // Harjutus 2: kolm toodet ja kolm erinevat kategooriat.
        var tooted = new[]
        {
            new Toode("Leib", 1.49m, Kategooria.Toit),
            new Toode("Mahl", 2.19m, Kategooria.Jook),
            new Toode("Puhastusvahend", 3.79m, Kategooria.Majapidamine)
        };
        Kontrolli(tooted.Length == 3, "Kolm toodet");
        Kontrolli(tooted[0].Nimi == "Leib" && tooted[0].Hind == 1.49m, "Toote omadused");
        Kontrolli(tooted[0].Kategooria == Kategooria.Toit, "Toidu kategooria");
        Kontrolli(tooted[1].Kategooria == Kategooria.Jook, "Joogi kategooria");
        Kontrolli(tooted[2].Kategooria == Kategooria.Majapidamine, "Majapidamise kategooria");

        // Harjutus 3: kõik staatused õiges järjekorras ja lõppolekust edasi ei liigu.
        Kontrolli((int)TellimuseStaatus.Uus == 0, "Uus = 0");
        Kontrolli((int)TellimuseStaatus.Tootmises == 1, "Tootmises = 1");
        Kontrolli((int)TellimuseStaatus.Saadetud == 2, "Saadetud = 2");
        Kontrolli((int)TellimuseStaatus.KohaleToimetatud == 3, "KohaleToimetatud = 3");

        var tellimus = new Tellimus();
        Kontrolli(tellimus.Staatus == TellimuseStaatus.Uus, "Algstaatus");

        var algneValjund = Console.Out;
        using var kirjutaja = new StringWriter();
        try
        {
            Console.SetOut(kirjutaja);
            tellimus.Jargmine();
            Kontrolli(tellimus.Staatus == TellimuseStaatus.Tootmises, "Esimene üleminek");
            tellimus.Jargmine();
            Kontrolli(tellimus.Staatus == TellimuseStaatus.Saadetud, "Teine üleminek");
            tellimus.Jargmine();
            Kontrolli(tellimus.Staatus == TellimuseStaatus.KohaleToimetatud, "Kolmas üleminek");
            tellimus.Jargmine();
            Kontrolli(tellimus.Staatus == TellimuseStaatus.KohaleToimetatud, "Lõppstaatust ei ületata");
        }
        finally
        {
            Console.SetOut(algneValjund);
        }

        string[] valjund = kirjutaja.ToString()
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        string[] oodatud = { "Tootmises", "Saadetud", "KohaleToimetatud", "KohaleToimetatud" };
        Kontrolli(valjund.SequenceEqual(oodatud), "Jargmine() väljastab staatuste nimed");

        Console.WriteLine("Kõik kolme harjutuse kontrollid läbitud.");
    }

    private static void Kontrolli(bool tingimus, string nimetus)
    {
        if (!tingimus)
            throw new Exception("Kontroll ebaõnnestus: " + nimetus);
    }
}
