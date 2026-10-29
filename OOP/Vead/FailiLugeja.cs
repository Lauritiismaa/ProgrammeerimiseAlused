namespace ProgrammeerimiseAlused.OOP.Vead;

public static class FailiLugeja
{
    // Harjutus 3: FileNotFoundException püütakse eraldi ning finally käivitub alati.
    // TextWriter võimaldab samasugust väljundit kontrollida ka testides.
    public static bool LoeFail(string failitee, TextWriter? valjund = null)
    {
        TextWriter kirjutaja = valjund ?? Console.Out;

        try
        {
            string sisu = File.ReadAllText(failitee);
            kirjutaja.WriteLine("Faili sisu:");
            kirjutaja.WriteLine(sisu);
            return true;
        }
        catch (FileNotFoundException)
        {
            kirjutaja.WriteLine("Fail puudub.");
            return false;
        }
        finally
        {
            // Käivitub nii edukal lugemisel kui ka faili puudumise korral.
            kirjutaja.WriteLine("Töö lõpetatud");
        }
    }
}
