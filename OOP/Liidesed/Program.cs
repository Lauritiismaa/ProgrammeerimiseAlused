using ProgrammeerimiseAlused.OOP.Liidesed;

Console.OutputEncoding = System.Text.Encoding.UTF8;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("OOP – Liidesed (4 harjutust)");

Console.WriteLine("\n1. IKujund: ring ja ristkülik");
var ring = new Ring(3);
var ristkülik = new Ristkülik(4, 5);
Console.WriteLine($"Ring: pindala = {ring.Pindala():F2}, ümbermõõt = {ring.Umbermoot():F2}");
Console.WriteLine($"Ristkülik: pindala = {ristkülik.Pindala():F2}, ümbermõõt = {ristkülik.Umbermoot():F2}");

Console.WriteLine("\n2. IKujund[] massiiv");
IKujund[] kujundid = { ring, ristkülik };
foreach (IKujund kujund in kujundid)
{
    Console.WriteLine($"{kujund.GetType().Name}: pindala = {kujund.Pindala():F2}");

    // Liidese eelis: sama kood töötab iga IKujund liidest rakendava kujundiga.
    // Tsükkel ei pea teadma, kas objekt on Ring või Ristkülik.
}

Console.WriteLine("\n3. INime : IDisposable ja using");
var ese = new NimegaEse("Õpik");
using (INime nimegaEse = ese)
{
    nimegaEse.Kirjelda();
}
Console.WriteLine($"Dispose() kutsuti välja: {ese.OnVabastatud}");

Console.WriteLine("\n4. Kahe liidese rakendamine");
IKujund kujundina = ristkülik;
IVarv arvuna = ristkülik;
Console.WriteLine($"Ristküliku pindala: {kujundina.Pindala():F2}");
Console.WriteLine($"Ristküliku külgede arv: {arvuna.KulgedeArv}");
