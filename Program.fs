open Ingredients

let ingredients =
    {
    Starter = 289.0; // grams
    StarterHydration = 1.0; // 1.0 = 100%
    Water = 260.2619048; // grams
    Flour = 450.7380952; // grams
    Salt = 9.0909; // grams
    }

let hydration = ingredients.Hydration

let ingredients2 = Components(289.0, 1.0, 0.68, 1000.0, 0.909090)
