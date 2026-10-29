using ProgrammeerimiseAlused.OOP.ObjektideVordlemine;

Console.OutputEncoding = System.Text.Encoding.UTF8;

if (args.Contains("--test"))
{
    Kontrollid.Käivita();
    return;
}

Console.WriteLine("HARJUTUS 1 – Equals()");
var toode1 = new Toode("A100", "Arvutihiir");
var toode2 = new Toode("A100", "Mängurihiir");
Console.WriteLine($"Tooted on erinevad isendid: {!ReferenceEquals(toode1, toode2)}");
Console.WriteLine($"Sama koodiga toodete Equals(): {toode1.Equals(toode2)}");

Console.WriteLine("\nHARJUTUS 2 – operaatorid == ja !=");
var erinevToode = new Toode("B200", "Klaviatuur");
Console.WriteLine($"toode1 == toode2: {toode1 == toode2}");
Console.WriteLine($"toode1 != toode2: {toode1 != toode2}");
Console.WriteLine($"toode1 == erinevToode: {toode1 == erinevToode}");
Console.WriteLine($"Equals ja == on sama tulemusega: {toode1.Equals(toode2) == (toode1 == toode2)}");

Console.WriteLine("\nHARJUTUS 3 – GetHashCode()");
Console.WriteLine($"Esimese toote räsikood: {toode1.GetHashCode()}");
Console.WriteLine($"Teise toote räsikood: {toode2.GetHashCode()}");
Console.WriteLine($"Võrdsete toodete räsikoodid on samad: {toode1.GetHashCode() == toode2.GetHashCode()}");

Console.WriteLine("\nHARJUTUS 4 – List<Toode>.Contains()");
var tooted = new List<Toode>
{
    new Toode("A100", "Arvutihiir"),
    new Toode("B200", "Klaviatuur"),
    new Toode("C300", "Monitor")
};

// Otsitav toode on eraldi loodud isend ning nimi on tahtlikult erinev.
var otsitav = new Toode("B200", "Teise nimega klaviatuur");

// Contains() kontrollib loendi elementide võrdsust EqualityComparer<Toode>.Default abil.
// Kuna Toode rakendab IEquatable<Toode> ja võrdleb ainult Kood väärtust,
// leitakse B200 ka siis, kui otsitav on teine objekt mälus.
Console.WriteLine($"Otsitav on loendi elemendiga erinev isend: {!ReferenceEquals(otsitav, tooted[1])}");
Console.WriteLine($"Kas loendis leidub kood {otsitav.Kood}? {tooted.Contains(otsitav)}");
