# Esimese tunni harjutused

Lauri Tiismaa

Allikas: [õpetaja tööleht 1](https://gunnarpeipman.com/kool/programmeerimine2/tunnid/01-tooleht/).
Varasemas ülesande kirjelduses nimetati neid 12.09 harjutusteks; praegusel veebilehel kuupäeva pole.

## Harjutused 3 ja 4: TereMaailm

Projekt asub kaustas `TereMaailm`. Esialgne Hello World programm salvestati commitiga
`Esimene commit`, seejärel lisati nime küsimine commitiga `Lisatud nime küsimine`.

Hoidla juurkaustas:

```sh
dotnet run --project 12-09-harjutused/TereMaailm
```

Näide:

```text
Mis su nimi on? Lauri
Tere, Lauri!
```

Ajalugu:

```sh
git log --oneline -- 12-09-harjutused/TereMaailm
git log -p -- 12-09-harjutused/TereMaailm/Program.cs
```

## Harjutused 1 ja 2: GitHubi konto ning profiil

Konto nimi ja lühitutvustus on lisatud. Avalik [profiilihoidla Lauritiismaa](https://github.com/Lauritiismaa/Lauritiismaa) on loodud ning selle README kuvatakse profiilil.

Eraldi avalik [TereMaailma hoidla](https://github.com/Lauritiismaa/TereMaailm) sisaldab programmi ja kahte harjutuse committi: `Esimene commit` ning `Lisatud nime küsimine`.

Veel tuleb valida profiilipilt ja seadistada konto 2FA. Ava projekt enda Visual Studios või VS Code'is, käivita see ning vaata muudatuste ajalugu.
