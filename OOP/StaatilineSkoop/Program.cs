using ProgrammeerimiseAlused.OOP.StaatilineSkoop;

Console.OutputEncoding = System.Text.Encoding.UTF8;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("OOP – Staatiline skoop (4 harjutust)");

Console.WriteLine("\n1. Loendur");
var esimene = new Loendur();
var teine = new Loendur();
var kolmas = new Loendur();
// Kõik kolm isendit suurendasid sama klassi staatilist omadust.
Console.WriteLine($"Loendur.Kokku: {Loendur.Kokku}");

Console.WriteLine("\n2. Staatiline Matemaatika");
int arv = 4;
Console.WriteLine($"Ruut({arv}) = {Matemaatika.Ruut(arv)}");
Console.WriteLine($"Kuup({arv}) = {Matemaatika.Kuup(arv)}");

Console.WriteLine("\n3. StringExtensions – laiendusmeetod");
string lause = "Täna õpime C# staatilisi meetodeid";
Console.WriteLine($"Lause: {lause}");
Console.WriteLine($"Sõnade arv: {lause.LoendaSonad()}");

Console.WriteLine("\n4. Konverter – staatiline konstruktor");
Console.WriteLine("Enne Konverter.VaikeYhik esimest lugemist.");
// Järgmise käsu käigus käivitub Konverteri staatiline konstruktor
// ja kuvab sellekohase teate enne vaikeühiku väärtuse väljastamist.
Console.WriteLine($"VaikeYhik: {Konverter.VaikeYhik}");
Console.WriteLine("Teine lugemine (konstruktor ei käivitu uuesti):");
Console.WriteLine($"VaikeYhik: {Konverter.VaikeYhik}");
