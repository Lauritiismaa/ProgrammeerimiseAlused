using ProgrammeerimiseAlused.OOP.Vead;

Console.OutputEncoding = System.Text.Encoding.UTF8;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("OOP – Vead (5 harjutust)");

Console.WriteLine("\n1. Jaga(int x, int y)");
Console.WriteLine($"12 / 3 = {Harjutused.Jaga(12, 3)}");
try
{
    Console.WriteLine($"12 / 0 = {Harjutused.Jaga(12, 0)}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Püütud viga: {ex.Message}");
}

Console.WriteLine("\n2. Toode ja negatiivse hinna keeld");
var toode = new Toode(14.99m);
Console.WriteLine($"Õige hind: {toode.Hind:0.00} €");
try
{
    var viganeToode = new Toode(-4.50m);
    Console.WriteLine(viganeToode.Hind);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Püütud viga: {ex.Message}");
}
Console.WriteLine($"Esimese toote hind jäi: {toode.Hind:0.00} €");

Console.WriteLine("\n3. Faili andmed.txt lugemine");
string olemasolevFail = Path.Combine(AppContext.BaseDirectory, "andmed.txt");
FailiLugeja.LoeFail(olemasolevFail);

Console.WriteLine("\nSama harjutus puuduva failiga");
string puuduvFail = Path.Combine(
    AppContext.BaseDirectory, "kindlasti_puuduv_fail_987654321.txt");
FailiLugeja.LoeFail(puuduvFail);

Console.WriteLine("\n4. LoePikkus(string s), InnerException ja stack trace");
Console.WriteLine($"Sõna pikkus: {Harjutused.LoePikkus("Tere")}");
try
{
    // null! lubab teadlikult katsetada nulliga, vältides nullable-hoiatust.
    Harjutused.LoePikkus(null!);
}
catch (ApplicationException ex)
{
    Console.WriteLine($"Uus erind: {ex.GetType().Name}: {ex.Message}");
    Console.WriteLine($"Algne põhjus: {ex.InnerException?.GetType().Name}");
    Console.WriteLine($"Algne veateade: {ex.InnerException?.Message}");
    // ToString() kuvab nii sisemise erindi kui ka välise erindi stack trace'i.
    Console.WriteLine("Stack trace koos sisemise veaga:");
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("\n5. Stopwatch – erindi püüdmine vs nullikontroll (10 000 elementi)");
var tulemus = JoudlusVordlus.Mooda();
Console.WriteLine($"try-catch:     {tulemus.TryCatchMs:F3} ms");
Console.WriteLine($"nullikontroll: {tulemus.KontrollMs:F3} ms");
Console.WriteLine($"Kontrollsumma (mõlemal sama): {tulemus.Summa}");
Console.WriteLine("Võrdlus: erindid on kulukad. Ennetav nullikontroll on tavaliselt kiirem.");
Console.WriteLine("Tegelikud mõõtmistulemused sõltuvad arvutist ja käivituskeskkonnast.");
