using ProgrammeerimiseAlused.OOP.Enumeraatorid;

Console.OutputEncoding = System.Text.Encoding.UTF8;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("OOP – Enumeraatorid (3 harjutust)");

// Harjutus 1: üks nädalapäev nii nime kui ka numbrina.
Console.WriteLine("\n1. Nädalapäev");
Nadalapaev paev = Nadalapaev.Kolmapäev;
Console.WriteLine($"Päeva nimi: {paev}");
Console.WriteLine($"Päeva number: {(int)paev}");

// Harjutus 2: kolm erineva kategooriaga toodet.
Console.WriteLine("\n2. Tooted");
Toode[] tooted =
{
    new Toode("Leib", 1.49m, Kategooria.Toit),
    new Toode("Mahl", 2.19m, Kategooria.Jook),
    new Toode("Nõudepesuvahend", 3.79m, Kategooria.Majapidamine)
};

foreach (Toode toode in tooted)
{
    Console.WriteLine($"{toode.Nimi} – {toode.Hind:0.00} € – {toode.Kategooria}");
}

// Harjutus 3: tellimuse oleku muutmine järgmisele tasemele.
Console.WriteLine("\n3. Tellimuse staatus");
var tellimus = new Tellimus();
Console.WriteLine($"Algstaatus: {tellimus.Staatus}");
tellimus.Jargmine(); // Tootmises
tellimus.Jargmine(); // Saadetud
tellimus.Jargmine(); // KohaleToimetatud
tellimus.Jargmine(); // Jääb KohaleToimetatud
