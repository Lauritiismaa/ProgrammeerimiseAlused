namespace ProgrammeerimiseAlused.OOP.Vead;

public static class Harjutused
{
    // Harjutus 1: nulliga jagamine annab DivideByZeroException-i.
    public static int Jaga(int x, int y)
    {
        if (y == 0)
            throw new DivideByZeroException("Nulliga ei saa jagada.");

        return x / y;
    }

    // Harjutus 4: algne NullReferenceException säilib InnerException omaduses.
    public static int LoePikkus(string s)
    {
        try
        {
            return s.Length;
        }
        catch (NullReferenceException algneViga)
        {
            throw new ApplicationException(
                "Teksti pikkuse lugemine ebaõnnestus: tekst oli null.",
                algneViga);
        }
    }
}
