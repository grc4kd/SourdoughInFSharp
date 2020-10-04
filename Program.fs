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

// tests before entrypoint
let testDecimal (expected : decimal) (actual : decimal) (threshold : decimal) =
    let difference = abs (expected - actual)
    match difference < threshold with
    | true -> 
        true
    | false -> 
        printfn "test failed, expected: %M, actual %M" expected actual
        false

let result1 = testDecimal 0.68M (decimal (Hydration 289.0 1.0 260.261905 450.738095)) 0.000001M
match result1 with
| true -> () // empty unit, do nothing if test passed
| false -> printfn "func Hydration test failed"

let testIngredientsExpected =
    {
        Starter = 289.0
        Water = 260.261905
        Flour = 450.738095
        Salt = 9.0909
    } 
let testIngredientsActual = Components 289.0 1.0 0.68 1000.0

let result2 = testDecimal (decimal testIngredientsExpected.Starter) (decimal testIngredientsActual.Starter) 0.000001M
let result3 = testDecimal (decimal testIngredientsExpected.Water) (decimal testIngredientsActual.Water) 0.000001M
let result4 = testDecimal (decimal testIngredientsExpected.Flour) (decimal testIngredientsActual.Flour) 0.000001M
let result5 = testDecimal (decimal testIngredientsExpected.Salt) (decimal testIngredientsActual.Salt) 0.000001M

let testsList = [ result1; result2; result3; result4; result5 ]

match result2, result3, result4, result5 with
| true, true, true, true -> () // empty unit, do nothing if test passed
| _, _, _, _ -> printfn "func Components test failed"

[<EntryPoint>]
let main argv =
    // break if some test did not pass
    if not (List.contains false testsList) then
        "ok"
    else
        failwith "Some program test(s) did not pass."
    |> ignore // explicitly ignore string output of the above if/else function

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
