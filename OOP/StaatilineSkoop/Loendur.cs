namespace ProgrammeerimiseAlused.OOP.StaatilineSkoop;

// Harjutus 1: static omadus kuulub klassile ja on ühine kõigile objektidele.
public class Loendur
{
    public static int Kokku { get; private set; }

    public Loendur()
    {
        Kokku++;
    }
}
