namespace ProgrammeerimiseAlused.OOP.Liidesed;

// Harjutus 3: INime kaudu on kohustuslikud nii Kirjelda() kui ka Dispose().
public class NimegaEse : INime
{
    public string Nimi { get; }
    public bool OnVabastatud { get; private set; }

    public NimegaEse(string nimi)
    {
        Nimi = nimi;
    }

    public void Kirjelda()
    {
        if (OnVabastatud)
            throw new ObjectDisposedException(nameof(NimegaEse));

        Console.WriteLine($"See on ese nimega {Nimi}.");
    }

    public void Dispose()
    {
        // Näites ei ole väliseid ressursse; märgime objekti suletuks,
        // et saaks kontrollida using-ploki automaatset Dispose()-kutset.
        OnVabastatud = true;
    }
}
