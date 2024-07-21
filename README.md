A straight-forward baking calculator for baking bread.
This version uses sourdough yeast, but instant yeast would be a popular use case.

## Options
- *h* for Calculate `h`ydration
- *c* for Calculate flour/water `c`omponents

## Example usage
### ex 1. `h` calculate hydration given starter mass, starter hydration, water mass, and flour mass
All units of mass are given in grams. Baker's math gives bread hydration as mass of water / mass of flour. 50% flour and 50% water are a 50:50 ratio and 100% baker's hydration.
```
myuser@localhost:~/github/SourdoughInFSharp/SourdoughInFSharp$ dotnet run --project src/App/
Calculate hydration (h) or flour/water/salt components (c)?h
Starter (g):200
Starter hydration (%):100
Water (g):344
Flour (g):455
Dough has a mass of 999.000000
Dough has 80.000000% hydration
```

### ex 2. `c` calculate components given starter hydration, desired dough hydration, desired dough mass, and a proportion for the ratio of starter to dough flour
These are common parameters in sourdough recipes.
```
house@house-tuxbox:~/github/SourdoughInFSharp_redux/SourdoughInFSharp$ dotnet run --project src/App/
Calculate hydration (h) or flour/water/salt components (c)?h
Starter (g):house@house-tuxbox:~/github/SourdoughInFSharp_redux/SourdoughInFSharp$ dotnet run --project src/App/
Calculate hydration (h) or flour/water/salt components (c)?c
Starter hydration (%):100
Desired dough hydration (%):80
Desired dough mass (g):1000 
Proportion starter to dough flour (prefermented dry weight) (%):20
starter (g):200.000000
water (g):344.444444
flour (g):455.555556
```
