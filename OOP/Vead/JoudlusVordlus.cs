using System.Diagnostics;

namespace ProgrammeerimiseAlused.OOP.Vead;

public static class JoudlusVordlus
{
    private const int ElementideArv = 10_000;
    private const int Kordusi = 15;

    public static (double TryCatchMs, double KontrollMs, long Summa) Mooda()
    {
        // Harjutus 5: täpselt 10 000 elementi; igal kümnendal kohal null.
        // Mõlemad lähenemised läbivad täpselt samu andmeid.
        List<string?> andmed = Enumerable.Range(0, ElementideArv)
            .Select(i => i % 10 == 0 ? (string?)null : "näide")
            .ToList();

        // Soojendus vähendab JIT-kompileerimise mõju mõõtmisele.
        long soojendusA = LoendaTryCatch(andmed);
        long soojendusB = LoendaKontrolliga(andmed);
        if (soojendusA != soojendusB)
            throw new InvalidOperationException("Võrreldavad lahendused andsid erineva tulemuse.");

        var kell = Stopwatch.StartNew();
        long summaA = 0;
        for (int i = 0; i < Kordusi; i++)
            summaA += LoendaTryCatch(andmed);
        kell.Stop();
        double tryCatchMs = kell.Elapsed.TotalMilliseconds;

        kell.Restart();
        long summaB = 0;
        for (int i = 0; i < Kordusi; i++)
            summaB += LoendaKontrolliga(andmed);
        kell.Stop();
        double kontrollMs = kell.Elapsed.TotalMilliseconds;

        if (summaA != summaB)
            throw new InvalidOperationException("Võrreldavad lahendused andsid erineva tulemuse.");

        return (tryCatchMs, kontrollMs, summaA);
    }

    private static long LoendaTryCatch(List<string?> andmed)
    {
        long pikkusKokku = 0;
        foreach (string? tekst in andmed)
        {
            try
            {
                // Nulli korral tekib erind: see on teadlikult aeglasem näide.
                pikkusKokku += tekst!.Length;
            }
            catch (NullReferenceException)
            {
                // Puuduv väärtus jäetakse vahele.
            }
        }
        return pikkusKokku;
    }

    private static long LoendaKontrolliga(List<string?> andmed)
    {
        long pikkusKokku = 0;
        foreach (string? tekst in andmed)
        {
            // Eelnev sanity check väldib erindi tekkimist.
            if (tekst is not null)
                pikkusKokku += tekst.Length;
        }
        return pikkusKokku;
    }
}
