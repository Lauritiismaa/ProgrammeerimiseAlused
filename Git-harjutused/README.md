# Git ja GitHub – praktilised näited

Allikas: [õpetaja materjal](https://gunnarpeipman.com/kool/programmeerimine2/git/).
Lehel selgitatakse käske ja töövooge; eraldi nummerdatud ülesannete loendit seal ei ole.
Siin on nende teemade praktiline läbimängimine.

## Hoidla ajaloos tehtud näide

1. Lisati `tervitus.txt` põhiharru.
2. Harus `harjutus/tervitus` muudeti tervitust.
3. Põhiharus muudeti sama rida teistmoodi.
4. Haru ühendamisel tekkis päris ühendamiskonflikt.
5. Konflikt lahendati ning salvestati kahe vanemaga merge-commitina.

[Konflikti sisu ja lahendus](konflikt-naide.md).

```sh
git log --graph --oneline --all
git log -p -- Git-harjutused/tervitus.txt
git status
```

## Korda ise eraldi harjutuskaustas

```sh
mkdir git-proov
cd git-proov
git init -b main
# Loo fail tervitus.txt sisuga Tere!
git status
git add tervitus.txt
git commit -m "Lisa tervitus"
git switch -c harjutus/tervitus
# Muuda faili sisu: Tere, Lauri!
git diff
git add tervitus.txt
git commit -m "Lisa nimi"
git switch main
# Muuda sama rida: Tere, programmeerija!
git add tervitus.txt
git commit -m "Muuda tervitust"
git merge harjutus/tervitus
# Eemalda konfliktimarkerid ja jäta sobiv tervitus.
git add tervitus.txt
git commit -m "Lahenda konflikt"
git log --graph --oneline --all
```

## Kaugserver ja pull request

Olemasoleva koolitööde hoidla allalaadimiseks:

```sh
git clone https://github.com/Lauritiismaa/ProgrammeerimiseAlused.git
cd ProgrammeerimiseAlused
git fetch origin
git pull --ff-only origin main
git switch -c harjutus/minu-muudatus
# Tee ja salvesta oma muudatus.
git add README.md
git commit -m "Täienda kirjeldust"
git push -u origin harjutus/minu-muudatus
```

Seejärel ava GitHubis pull request põhiharru `main`, vaata diff üle ning ühenda muudatus.
GitHubi autentimiseks kasuta enda kontot; ära salvesta ligipääsutõendeid lähtekoodi.

Kohalikud käsud ja GitHubi avaldamine on eri toimingud. Selles keskkonnas tehakse GitHubi kirjutamine ühenduse API kaudu; see ei tähenda, et sinu arvutis oleks `git push` autentimine juba seadistatud.
