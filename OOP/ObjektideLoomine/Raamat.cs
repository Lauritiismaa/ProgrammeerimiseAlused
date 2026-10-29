namespace ProgrammeerimiseAlused.OOP.ObjektideLoomine;

public class Raamat
{
    public string Pealkiri { get; set; }
    public string Autor { get; set; }
    public int Aasta { get; set; }

    // Harjutus 3: kahe parameetriga konstruktor kutsub teist konstruktorit.
    // Kui aastat ei anta, jääb väärtuseks 0 (määramata).
    public Raamat(string pealkiri, string autor) : this(pealkiri, autor, 0)
    {
    }

    public Raamat(string pealkiri, string autor, int aasta)
    {
        Pealkiri = pealkiri;
        Autor = autor;
        Aasta = aasta;
    }
}
