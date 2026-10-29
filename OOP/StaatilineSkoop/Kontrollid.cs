using ProgrammeerimiseAlused.OOP.StaatilineSkoop;

public static class Kontrollid
{
    public static void Käivita()
    {
        // Harjutus 1: iga loodud Loendur suurendab ühist staatilist loendurit.
        int algvaartus = Loendur.Kokku;
        _ = new Loendur();
        _ = new Loendur();
        _ = new Loendur();
        Kontrolli(Loendur.Kokku == algvaartus + 3, "Loendur.Kokku kasvab kolme võrra");

        // Harjutus 2: staatilised ruudu- ja kuubimeetodid.
        Kontrolli(Matemaatika.Ruut(4) == 16, "Ruut(4)");
        Kontrolli(Matemaatika.Kuup(4) == 64, "Kuup(4)");
        Kontrolli(Matemaatika.Ruut(-3) == 9, "Ruut(-3)");
        Kontrolli(Matemaatika.Kuup(-3) == -27, "Kuup(-3)");

        // Harjutus 3: tühikute järgi lugemine, ka järjestikuste tühikute puhul.
        Kontrolli("Üks kaks kolm".LoendaSonad() == 3, "Kolm sõna");
        Kontrolli("  üks   kaks  ".LoendaSonad() == 2, "Üleliigsed tühikud");
        Kontrolli("".LoendaSonad() == 0, "Tühi tekst");
        Kontrolli("   ".LoendaSonad() == 0, "Ainult tühikud");

        // Harjutus 4: esimesel ligipääsul täidetakse staatiline konstruktor
        // ja teisel ligipääsul seda uuesti ei käivitata.
        var algneValjund = Console.Out;
        using var salvestaja = new StringWriter();
        string esmakordne;
        string teineKord;

        try
        {
            Console.SetOut(salvestaja);
            esmakordne = Konverter.VaikeYhik;
            teineKord = Konverter.VaikeYhik;
        }
        finally
        {
            Console.SetOut(algneValjund);
        }

        Kontrolli(esmakordne == "km" && teineKord == "km", "Konverteri vaikeühik");
        string[] read = salvestaja.ToString().Split(
            '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        Kontrolli(read.Count(r => r == "Konverteri staatiline konstruktor käivitus.") == 1,
            "Staatiline konstruktor käivitub ainult korra");

        Console.WriteLine("Kõik nelja harjutuse kontrollid läbitud.");
    }

    private static void Kontrolli(bool tingimus, string nimetus)
    {
        if (!tingimus)
            throw new Exception("Kontroll ebaõnnestus: " + nimetus);
    }
}
