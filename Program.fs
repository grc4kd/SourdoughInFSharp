open System

type Ingredients =
    {
        Starter : float
        Water : float
        Flour : float
        Salt : float
    }

let Hydration starter starterHydration water flour =
    let sD = starter / (starterHydration + 1.0)
    let sW = (starterHydration * starter) / (starterHydration + 1.0)
    let wet = sW + water
    let dry = sD + flour
    wet / dry

let Components starter starterHydration desiredHydration desiredMass =
    let sD = starter / (starterHydration + 1.0)
    let sW = (starterHydration * starter) / (starterHydration + 1.0)
    let flour = (desiredMass - sD - (desiredHydration * sD)) / (desiredHydration + 1.0)
    {
        Starter = starter
        Water = desiredMass - sD - sW - flour
        Flour = flour
        Salt = (desiredMass * 0.909090) / 100.0
    }

[<EntryPoint>]
let main argv =
    printf "Calculate hydration (h) or flour/water/salt components (c)?";
    let calcBranch = Console.ReadLine();

    match calcBranch with
    | "h" ->
        printf "Starter (g):";
        let starter = float (Console.ReadLine());
        printf "Starter hydration (%%):";
        let starterHydration = float (Console.ReadLine()) / 100.0;
        printf "Water (g):";
        let water = float (Console.ReadLine());
        printf "Flour (g):";
        let flour = float (Console.ReadLine());

        let hydration = Hydration starter starterHydration water flour;

        printfn "Dough has a mass of %f" (starter + water + flour)
        printfn "Dough has %f%% hydration" (hydration * 100.0);
    | "c" ->
        printf "Starter (g):";
        let starter = float (Console.ReadLine());
        printf "Starter hydration (%%):";
        let starterHydration = float (Console.ReadLine()) / 100.0;
        printf "Desired dough hydration (%%):"
        let desiredHydration = float (Console.ReadLine()) / 100.0;
        printf "Desired dough mass (g):";
        let desiredMass = float (Console.ReadLine());

        let ingredients = Components starter starterHydration desiredHydration desiredMass

        printfn "water (g):%f" ingredients.Water;
        printfn "flour (g):%f" ingredients.Flour;
        printfn "salt (tsp):%f" (ingredients.Salt / 2.3);
    | _ -> printfn "Invalid option, please choose from the available functions."
    
    0 // return an integer exit code
