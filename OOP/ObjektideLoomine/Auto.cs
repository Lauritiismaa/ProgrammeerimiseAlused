namespace ProgrammeerimiseAlused.OOP.ObjektideLoomine;

public class Auto
{
    public string Mark { get; set; } = string.Empty;
    public string Mudel { get; set; } = string.Empty;
    public int Aasta { get; set; }

    // Harjutus 2: parameetriteta konstruktor võimaldab objekti initsialiseerijat.
    public Auto()
    {
    }

    // Harjutused 1 ja 2: konstruktor kolme parameetriga.
    public Auto(string mark, string mudel, int aasta)
    {
        Mark = mark;
        Mudel = mudel;
        Aasta = aasta;
    }
}
