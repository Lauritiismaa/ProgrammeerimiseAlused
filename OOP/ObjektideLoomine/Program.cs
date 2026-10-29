using ProgrammeerimiseAlused.OOP.ObjektideLoomine;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("HARJUTUS 1 – Auto parameetritega konstruktor");
var auto1 = new Auto("Toyota", "Corolla", 2020);
var auto2 = new Auto("Volvo", "V60", 2022);
KuvaAuto(auto1);
KuvaAuto(auto2);

Console.WriteLine("\nHARJUTUS 2 – Auto parameetriteta konstruktor ja objekti initsialiseerija");
var auto3 = new Auto
{
    Mark = "Škoda",
    Mudel = "Octavia",
    Aasta = 2019
};
var auto4 = new Auto("Audi", "A4", 2021);
KuvaAuto(auto3);
KuvaAuto(auto4);

Console.WriteLine("\nHARJUTUS 3 – Raamat ja konstruktorite ahel");
var raamat1 = new Raamat("Kevade", "Oskar Luts");
var raamat2 = new Raamat("Tõde ja õigus", "A. H. Tammsaare", 1926);
KuvaRaamat(raamat1);
KuvaRaamat(raamat2);

Console.WriteLine("\nHARJUTUS 4 – Toode ja hinnaks vaikimisi 0");
var toode1 = new Toode("Pliiats");
var toode2 = new Toode("Vihik", 2.50m);
KuvaToode(toode1);
KuvaToode(toode2);
Console.WriteLine($"Hindade erinevus: {toode2.Hind - toode1.Hind:0.00} €");

static void KuvaAuto(Auto auto)
{
    Console.WriteLine($"Mark: {auto.Mark}, mudel: {auto.Mudel}, aasta: {auto.Aasta}");
}

static void KuvaRaamat(Raamat raamat)
{
    string aastaTekst = raamat.Aasta == 0 ? "määramata" : raamat.Aasta.ToString();
    Console.WriteLine($"Pealkiri: {raamat.Pealkiri}, autor: {raamat.Autor}, aasta: {aastaTekst}");
}

static void KuvaToode(Toode toode)
{
    Console.WriteLine($"Nimi: {toode.Nimi}, hind: {toode.Hind:0.00} €");
}
