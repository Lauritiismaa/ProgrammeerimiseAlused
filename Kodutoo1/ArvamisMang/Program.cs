// Arv, mille mängija peab ära arvama.
int salajaneArv = 42;

Console.WriteLine("Arva ära täisarv vahemikus 1 kuni 100!");

while (true)
{
    Console.Write("Sinu pakkumine: ");
    string? sisend = Console.ReadLine();

    // Lõpeta, kui sisend suletakse.
    if (sisend == null)
    {
        break;
    }

    if (!int.TryParse(sisend, out int pakkumine))
    {
        Console.WriteLine("Palun sisesta täisarv.");
        continue;
    }

    if (pakkumine > salajaneArv)
    {
        Console.WriteLine("Pakkumine on liiga suur. Proovi uuesti!");
    }
    else if (pakkumine < salajaneArv)
    {
        Console.WriteLine("Pakkumine on liiga väike. Proovi uuesti!");
    }
    else
    {
        Console.WriteLine("Õige! Arvasid arvu ära.");
        break;
    }
}
