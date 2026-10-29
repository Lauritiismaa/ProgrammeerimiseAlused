namespace ProgrammeerimiseAlused.OOP.Parilus;

// Harjutus 4: katse pärida sealed-klassist.
// Selle näite aktiveerimisel tekib kompilaatoriviga CS0509:
// 'Taksi': cannot derive from sealed type 'Koer'.
// Põhjus: Koer on märgitud sealed-klassiks ja C# keelab sellest pärimise.
//
// Näide on vaikimisi välja lülitatud, et teised harjutused kompileeruksid.
// Proovimiseks käivita:
// dotnet build OOP/Parilus/Parilus.csproj -p:DefineConstants=SEALED_VEA_NAIDE
#if SEALED_VEA_NAIDE
public class Taksi : Koer
{
    public Taksi(string nimi, int vanus) : base(nimi, vanus)
    {
    }
}
#endif
