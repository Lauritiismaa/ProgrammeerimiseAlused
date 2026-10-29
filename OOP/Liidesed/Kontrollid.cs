using ProgrammeerimiseAlused.OOP.Liidesed;

public static class Kontrollid
{
    public static void Käivita()
    {
        // Harjutus 1: liidese meetodite matemaatika.
        IKujund ring = new Ring(3);
        IKujund ristkülik = new Ristkülik(4, 5);
        Kontrolli(Ligikaudu(ring.Pindala(), 9 * Math.PI), "Ringi pindala");
        Kontrolli(Ligikaudu(ring.Umbermoot(), 6 * Math.PI), "Ringi ümbermõõt");
        Kontrolli(Ligikaudu(ristkülik.Pindala(), 20), "Ristküliku pindala");
        Kontrolli(Ligikaudu(ristkülik.Umbermoot(), 18), "Ristküliku ümbermõõt");

        // Harjutus 2: mitu erinevat objekti sama IKujund-liidese kaudu.
        IKujund[] kujundid = { ring, ristkülik };
        Kontrolli(kujundid.Length == 2, "Kahe kujundiga massiiv");
        Kontrolli(Ligikaudu(kujundid[0].Pindala(), 9 * Math.PI)
                  && Ligikaudu(kujundid[1].Pindala(), 20),
                  "Polümorfne pindala arvutamine");

        // Harjutus 3: INime pärib IDisposable ning using kutsub Dispose().
        var ese = new NimegaEse("Õpik");
        using (INime nimi = ese)
        {
            Kontrolli(nimi is IDisposable, "IDisposable rakendamine");
            nimi.Kirjelda();
            Kontrolli(!ese.OnVabastatud, "Objekt on using-plokis avatud");
        }
        Kontrolli(ese.OnVabastatud, "Dispose kutsuti using-ploki lõpus");

        // Harjutus 4: üks Ristkülik täidab kaht eri liidest.
        var kaheLiidesega = new Ristkülik(2, 7);
        IKujund pindalaLiides = kaheLiidesega;
        IVarv arvLiides = kaheLiidesega;
        Kontrolli(Ligikaudu(pindalaLiides.Pindala(), 14), "Esimene liides");
        Kontrolli(arvLiides.KulgedeArv == 4, "Teine liides");

        Console.WriteLine("Kõik nelja harjutuse kontrollid läbitud.");
    }

    private static bool Ligikaudu(double tegelik, double oodatud)
    {
        return Math.Abs(tegelik - oodatud) < 0.000001;
    }

    private static void Kontrolli(bool tingimus, string nimetus)
    {
        if (!tingimus)
            throw new Exception("Kontroll ebaõnnestus: " + nimetus);
    }
}
