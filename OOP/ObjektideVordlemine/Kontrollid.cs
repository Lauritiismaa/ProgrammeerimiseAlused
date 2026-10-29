using ProgrammeerimiseAlused.OOP.ObjektideVordlemine;

public static class Kontrollid
{
    public static void Käivita()
    {
        var esimene = new Toode("100", "Esimene nimi");
        var teine = new Toode("100", "Teine nimi");
        var kolmas = new Toode("200", "Kolmas nimi");

        // 1. Equals kontrollib koode, mitte nimesid ega objektiviiteid.
        Nõua(!ReferenceEquals(esimene, teine), "Erinevad isendid");
        Nõua(esimene.Equals(teine), "Sama koodiga toodete Equals");
        Nõua(!esimene.Equals(kolmas), "Erineva koodiga toodete Equals");
        Nõua(!esimene.Equals("100"), "Võrdlus teist tüüpi objektiga");

        // 2. Operaatorid == ja != annavad Equals-iga kooskõlalised tulemused.
        Nõua(esimene == teine, "Võrdusoperaator sama koodiga");
        Nõua(!(esimene != teine), "Ebavõrdsusoperaator sama koodiga");
        Nõua(esimene != kolmas, "Ebavõrdsusoperaator erineva koodiga");
        Nõua((esimene == kolmas) == esimene.Equals(kolmas), "== ja Equals kooskõla");
        Toode? tyhi = null;
        Nõua(tyhi == null && null == tyhi, "Null == null");
        Nõua(esimene != null && null != esimene, "Toode != null");

        // 3. Samaväärsetel toodetel on sama räsikood.
        Nõua(esimene.GetHashCode() == teine.GetHashCode(), "Võrdsete toodete räsikoodid");

        // 4. Contains kasutab väärtuspõhist võrdsust ka teise isendi puhul.
        var nimekiri = new List<Toode> { esimene, kolmas, new Toode("300", "Neljas") };
        Nõua(nimekiri.Contains(new Toode("200", "Teine kirjeldus")), "Contains leiab sama koodi");
        Nõua(!nimekiri.Contains(new Toode("400", "Puuduv toode")), "Contains ei leia puuduvat koodi");
        Nõua(new HashSet<Toode> { esimene, teine }.Count == 1,
            "HashSet käsitleb sama koodiga tooteid võrdsena");

        Console.WriteLine("Kõik nelja harjutuse kontrollid läbitud.");
    }

    private static void Nõua(bool tingimus, string nimetus)
    {
        if (!tingimus)
            throw new Exception("Kontroll ebaõnnestus: " + nimetus);
    }
}
