using ProgrammeerimiseAlused.OOP.Parilus;

public static class Kontrollid
{
    public static void Käivita()
    {
        var koer = new Koer("Muki", 4);
        var kass = new Kass("Miisu", 2);

        Kontrolli(koer.Nimi == "Muki" && koer.Vanus == 4, "Koera andmed");
        Kontrolli(kass.Nimi == "Miisu" && kass.Vanus == 2, "Kassi andmed");
        Kontrolli(koer.Liik == "Koer" && kass.Liik == "Kass", "Abstraktse omaduse ülekirjutamine");

        // Kontrollitakse baasklassi tüübi kaudu, et käivituvad eri override-meetodid.
        Lemmikloom[] loomad = { koer, kass };
        Kontrolli(loomad.Length == 2, "Lemmikloom massiiv");
        Kontrolli(HaalitsuseTekst(loomad[0]) == "Auh-auh!", "Koera virtuaalne meetod");
        Kontrolli(HaalitsuseTekst(loomad[1]) == "Mjäu!", "Kassi virtuaalne meetod");

        Kontrolli(typeof(Lemmikloom).IsAbstract, "Baasklass on abstract");
        Kontrolli(typeof(Lemmikloom).GetProperty(nameof(Lemmikloom.Liik))?.GetMethod?.IsAbstract == true,
            "Liik omadus on abstract");
        Kontrolli(typeof(Koer).IsSealed, "Koer on sealed");

        Console.WriteLine("Kõik päriluse harjutuste kontrollid läbitud.");
    }

    private static string HaalitsuseTekst(Lemmikloom loom)
    {
        var algneValjund = Console.Out;
        using var kirjutaja = new StringWriter();
        try
        {
            Console.SetOut(kirjutaja);
            loom.Haalitse();
        }
        finally
        {
            Console.SetOut(algneValjund);
        }

        return kirjutaja.ToString().Trim();
    }

    private static void Kontrolli(bool tingimus, string nimetus)
    {
        if (!tingimus)
            throw new Exception("Kontroll ebaõnnestus: " + nimetus);
    }
}
