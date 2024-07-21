// open System
// open Library

// [<EntryPoint>]
// let main args =
//     printfn "Nice command-line arguments! Here's what System.Text.Json has to say about them:"

//     let value, json = getJson {| args=args; year=System.DateTime.Now.Year |}
//     printfn $"Input: %0A{value}"
//     printfn $"Output: %s{json}"

//     0 // return an integer exit code

open Library

open System

[<EntryPoint>]
let main argv =
    printf "Calculate hydration (h) or flour/water/salt components (c)?"
    let calcBranch = Console.ReadLine()

    match calcBranch with
    | "h" ->
        printf "Starter (g):"
        let starter = float (Console.ReadLine())
        printf "Starter hydration (%%):"
        let starterHydration = float (Console.ReadLine()) / 100.0
        printf "Water (g):"
        let water = float (Console.ReadLine())
        printf "Flour (g):"
        let flour = float (Console.ReadLine())

        let hydration = Hydration starter starterHydration water flour

        printfn "Dough has a mass of %f" (starter + water + flour)
        printfn "Dough has %f%% hydration" (hydration * 100.0)
        
    | "c" ->
        printf "Starter hydration (%%):"
        let starterHydration = float (Console.ReadLine()) / 100.0
        printf "Desired dough hydration (%%):"
        let desiredHydration = float (Console.ReadLine()) / 100.0
        printf "Desired dough mass (g):"
        let desiredMass = float (Console.ReadLine())
        printf "Proportion starter to dough flour (prefermented dry weight) (%%):"
        let starterRatio = float (Console.ReadLine()) / 100.0

        let components = DoughComponents starterHydration desiredHydration desiredMass starterRatio

        printfn "starter (g):%f" components.Ingredients.Starter
        printfn "water (g):%f" components.Ingredients.Water
        printfn "flour (g):%f" components.Ingredients.Flour

    | _ -> printfn "Invalid option, please choose from the available functions."
    
    0 // return an integer exit code