module Library

open Responses

open System.Text.Json

let getJson value =
    let json = JsonSerializer.Serialize(value)
    value, json

let Hydration (starter: float) (starterHydration: float) (water: float) (flour: float) : float =
    let wet = water + ((starterHydration * starter) / (starterHydration + 1.0))
    let dry = flour + (starter / (starterHydration + 1.0))
    wet / dry

let ComputeIngredients (starter: float) (starterHydration: float) (finalHydration: float) (finalMass: float) : Ingredients =
    let starterDry = starter / (starterHydration + 1.0)
    let starterWet = (starterHydration * starter) / (starterHydration + 1.0)
    let flour = (finalMass - starterDry - (finalHydration * starterDry)) / (finalHydration + 1.0)
    {
        Starter = starter
        Water = finalMass - starterDry - starterWet - flour
        Flour = flour
    }

let DoughComponents (starterHydration: float) (desiredHydration: float) (desiredMass : float) (starterRatio: float): Components =
    let starter = desiredMass * starterRatio
    let ingredients = ComputeIngredients starter starterHydration desiredHydration desiredMass
    {
        StarterHydration = Hydration starter starterHydration ingredients.Water ingredients.Flour
        Ingredients = ingredients
    }
