# 2. kodutöö – RSS-uudiste agregaator

**Autor:** Lauri Tiismaa  
**Aine:** Programmeerimise alused  
**Ülesanne:** https://gunnarpeipman.com/kool/programmeerimise-alused/kodutoo-2/

## Mida programm teeb?

C# konsooliprogramm loeb XML-põhiseid RSS-uudisvooge (Postimees, Lääne Elu, Äripäev ja ERR), koondab uudised `List<RssItem>` kogumisse ning võtab LINQ-iga 20 kõige värskemat uudist. Korduvad lingid eemaldatakse. Seejärel kirjutatakse uudised UTF-8 kodeeringus faili `uudised.html`.

HTML-failis on `<ul>` ja `<li>` elementidega loend. Iga uudise juures on klikitav pealkiri, avaldamise aeg, väljaanne ning lühikirjeldus. HTML-is on lihtne kujundus ja tekstid on turvaliselt kodeeritud.

Programm jätkab ka siis, kui mõni uudisvoog on ajutiselt kättesaamatu. Kui kõik vood ebaõnnestuvad, näidatakse veateadet ega kirjutata tühja uudistefaili.

## Käivitamine

Vaja on **.NET 8 SDK** või uuemat sobivat SDK-d.

1. Ava terminal projektikaustas `Kodutoo2`.
2. Käivita: `dotnet run`
3. Ava loodud `uudised.html` veebibrauseris. Fail luuakse programmi jooksva töökataloogi sisse (terminalist käivitades üldjuhul `Kodutoo2` kausta).

Visual Studios saab avada ka faili `Kodutoo2.csproj`, vajutada **Start** ja avada konsoolis näidatud HTML-faili asukoha.

## Lisaharjutus: kiiruse mõõtmine ja paralleelne lugemine

- `dotnet run -- --paralleelselt` – vood loetakse korraga, kasutatakse `Task.Run`, `Task.WhenAll` ja `ConcurrentBag<RssItem>`.
- `dotnet run -- --vordle` – programm teeb järjestikuse ja paralleelse katse, mõõdab `Stopwatch` abil RSS-voogude laadimise ja mõlema katse kogu tööaja ning väljastab kiiruste suhte. Tulemused salvestatakse eraldi failidesse `uudised_jarjest.html` ja `uudised.html`.

Paralleelne variant on eelkõige õppe-eesmärgil: asünkroonsetel HTTP-päringutel ei ole `Task.Run` tingimata vajalik. Mõõdetud ajad olenevad võrgu- ja serverikiirusest ning võivad iga käivitusega erineda.

## Koodifailid

- `Program.cs` – voogude allalaadimine, XML lugemine, järjestamine, HTML salvestamine ja aja mõõtmine.
- `RssItem.cs` – ühe uudise andmemudel.
- `Kodutoo2.csproj` – .NET-i projekti konfiguratsioon.

**Märkus:** Väljaannete RSS-aadressid pärinevad ülesande juhendist. Kui mõni väljaanne muudab oma URL-i või blokeerib automaatseid päringuid, tuleb vastavat aadressi failis `Program.cs` uuendada.
