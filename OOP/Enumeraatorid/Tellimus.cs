namespace ProgrammeerimiseAlused.OOP.Enumeraatorid;

// Harjutus 3: tellimuse staatus muutub ühe sammu kaupa.
public class Tellimus
{
    public TellimuseStaatus Staatus { get; private set; } = TellimuseStaatus.Uus;

    public void Jargmine()
    {
        if (Staatus < TellimuseStaatus.KohaleToimetatud)
        {
            // Teisendame enumi arvuks, suurendame ühe võrra ja teisendame tagasi.
            Staatus = (TellimuseStaatus)((int)Staatus + 1);
        }

        // Viimasest staatusest edasi ei liigu. Väljastame alati kehtiva staatuse.
        Console.WriteLine(Staatus);
    }
}
