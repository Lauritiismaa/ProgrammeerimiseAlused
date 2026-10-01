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

Konto ja koolitööde hoidla on olemas. Profiili README sisu on valmis failis
[Profiil/README.md](Profiil/README.md).

Järgmised sammud ei ole selle hoidla failide lisamisega automaatselt täidetud:

- Kontrolli GitHubi profiilipilti ja lühitutvustust.
- Lülita konto seadetes sisse kahefaktoriline autentimine (2FA).
- Loo avalik hoidla `Lauritiismaa` ning pane sinna faili `Profiil/README.md` sisu nimega `README.md`. See ilmub GitHubi profiilile.
- Tööleht palub luua ka eraldi avaliku `TereMaailm` hoidla. Siin asub sama projekt koolitööde ühishoidlas.
- Ava projekt enda Visual Studios või VS Code'is, käivita see ja vaata muudatuste ajalugu.

Kontoga seotud seadistusi ega Visual Studio kasutamist ei ole sinu eest tehtuks märgitud.
