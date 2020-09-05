// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    printf "Calculate hydration (h) or flour/water/salt components (c)?";
    let calcBranch = Console.ReadLine();

    if calcBranch = "h" then
        printf "Starter (g):";
        let starter = Console.ReadLine();
        printf "Starter hydration (%%):";
        let starterHydration = Console.ReadLine();
        printf "Water (g):";
        let water = Console.ReadLine();
        printf "Flour (g):";
        let flour = Console.ReadLine();

        let s = (float)starter;
        let sH = (float)starterHydration / 100.0;
        let w = (float)water;
        let f = (float)flour;

        let sD = s / (sH + 1.0);
        let sW = (sH * s) / (sH + 1.0);
        let wet = sW + w;
        let dry = sD + f;
        let hydration = wet / dry;

        printfn "Dough has %f%% hydration" (hydration * 100.0);
    elif calcBranch = "c" then
        printf "Starter (g):";
        let starter = Console.ReadLine();
        printf "Starter hydration (%%):";
        let starterHydration = Console.ReadLine();
        printf "Desired dough hydration (%%):"
        let hydration = Console.ReadLine();
        printf "Desired dough mass (g):";
        let mass = Console.ReadLine();

        let s = (float)starter;
        let sH = (float)starterHydration / 100.0;
        let h = (float)hydration / 100.0;
        let m = (float)mass;

        let sD = s / (sH + 1.0);
        let sW = (sH * s) / (sH + 1.0);
        let flour = (m - sD - (h * sD)) / (h + 1.0);
        let water = m - sD - sW - flour;
        let salt = (m * 0.909090) / 100.0;

        printfn "flour (g):%f" flour;
        printfn "water (g):%f" water;
        printfn "salt (tsp):%f" (salt / 2.3);
    
    0 // return an integer exit code
