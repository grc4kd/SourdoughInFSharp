module Tests

open Xunit
open System
open Library

let precision = 0.000001

[<Fact>]
let ``Hydration_PredictableParameters_SuccessfulResponse`` () =
    let expectedFinalHydration: float = 0.68
    let (starter, starterHydration, water, flour) = (289.0, 1.0, 260.261905, 450.738095)

    let actualFinalHydration = Hydration starter starterHydration water flour
    Assert.Equal(expectedFinalHydration, actualFinalHydration, precision)

[<Fact>]
let ``ComputeIngredients_PredictableParameters_SuccessfulResponse`` =
    let actual = ComputeIngredients 289.0 1.0 0.68 1000.0

    Assert.Equal(289.0, actual.Starter, precision)
    Assert.Equal(260.261905, actual.Water, precision)
    Assert.Equal(450.738095, actual.Flour, precision)

[<Fact>]
let ``DoughComponents_PredictableParameters_SuccessfulResponse`` =
    let (starterHydration, desiredHydration,  desiredMass, starterRatio) = (1.0, 0.68, 1000, 0.2)
    
    let actual = DoughComponents starterHydration desiredHydration desiredMass starterRatio

    Assert.Equal(0.680000, actual.StarterHydration, precision)
    Assert.Equal(289.261905, actual.Ingredients.Water, precision)
    Assert.Equal(450.738095, actual.Ingredients.Flour, precision)
