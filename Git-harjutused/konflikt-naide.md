# Ühendamiskonflikti näide

Sama faili esimene rida muudeti kahes harus erinevalt. Git tekitas järgmise konflikti:

```text
    <<<<<<< HEAD
Tere, programmeerija!
    =======
Tere, Lauri!
    >>>>>>> harjutus/tervitus
```

Lahendus ühendab mõlema tervituse mõtte. Konfliktimarkerid eemaldati ja tehti merge-commit. Tulemus on failis `tervitus.txt`.
