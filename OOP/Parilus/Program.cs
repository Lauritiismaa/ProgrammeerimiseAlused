using ProgrammeerimiseAlused.OOP.Parilus;

Console.OutputEncoding = System.Text.Encoding.UTF8;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("OOP – Pärilus (harjutused 1–4)");
Console.WriteLine();

// Harjutus 1: Koer ja Kass pärivad abstraktsest baasklassist Lemmikloom.
var koer = new Koer("Muki", 4);
var kass = new Kass("Miisu", 2);

Console.WriteLine("1. Kaks looma ja nende häälitsused");
Console.Write($"{koer.Nimi} ({koer.Liik}, {koer.Vanus} a): ");
koer.Haalitse();
Console.Write($"{kass.Nimi} ({kass.Liik}, {kass.Vanus} a): ");
kass.Haalitse();

Console.WriteLine();
Console.WriteLine("2. Lemmikloom[] massiiv ja polümorfism");

// Harjutus 2: sama baasklassi tüüpi massiiv sisaldab eri alamklasse.
Lemmikloom[] loomad = { koer, kass };

foreach (Lemmikloom loom in loomad)
{
    Console.Write($"{loom.Nimi} ({loom.Liik}): ");
    loom.Haalitse();

    // Hoolimata muutuja tüübist Lemmikloom valitakse käitusajal
    // tegeliku objekti (Koer või Kass) override-meetod.
}

Console.WriteLine();
Console.WriteLine("3. Lemmikloom on abstraktne; Koer ja Kass määravad omaduse Liik.");
Console.WriteLine("4. Koer on sealed. Vea CS0509 näide on failis SealedNaide.cs.");
