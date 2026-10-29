using OOP.Klassid;

if (args.Length > 0 && args[0] == "--test")
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("=== OOP: Klassid – viis harjutust ===");

Console.WriteLine("\n1. Raamat");
var raamat = new Raamat
{
    Pealkiri = "Kevade",
    Autor = "Oskar Luts",
    LehekülgedeArv = 300
};
Console.WriteLine($"Pealkiri: {raamat.Pealkiri}");
Console.WriteLine($"Autor: {raamat.Autor}");
Console.WriteLine($"Lehekülgi: {raamat.LehekülgedeArv}");

Console.WriteLine("\n2. PangaKonto");
var konto = new PangaKonto();
konto.Deposit(1500);
Console.WriteLine($"Pärast sissemakset: {konto.Balance:F2} €");
Console.WriteLine($"250 € väljamakse õnnestus: {konto.Withdraw(250)}");
Console.WriteLine($"1001 € väljamakse õnnestus: {konto.Withdraw(1001)}");
Console.WriteLine($"Kontojääk: {konto.Balance:F2} €");

Console.WriteLine("\n3. Temperatuur");
var temperatuur = new Temperatuur();
temperatuur.Celsius = 22;
Console.WriteLine($"Celsius: {temperatuur.Celsius:F2} °C");
Console.WriteLine($"Fahrenheit: {temperatuur.Fahrenheit:F2} °F");

Console.WriteLine("\n4. Kalkulaator");
var kalkulaator = new Kalkulaator();
Console.WriteLine($"3 × 4 = {kalkulaator.Korruta(3, 4)}");
Console.WriteLine($"2 × 3 × 4 = {kalkulaator.Korruta(2, 3, 4)}");

Console.WriteLine("\n5. Taimer");
var taimer = new Taimer();
taimer.AegTais += () => Console.WriteLine("Aeg täis!");
taimer.Alusta(1);
