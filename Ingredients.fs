module Ingredients
    let StarterDry(starter, starterHydration) =
        starter / (starterHydration + 1.0)

    let StarterWet(starter, starterHydration) =
        (starterHydration * starter) / (starterHydration + 1.0)

    type Ingredients =
        {
        Starter: float
        StarterHydration: float
        Water: float
        Flour: float
        Salt: float
        }

        member this.StarterDry =
            StarterDry(this.Starter, this.StarterHydration)

        member this.StarterWet =
            StarterWet(this.Starter, this.StarterHydration)

        member this.Hydration =
            let wet = this.StarterWet + this.Water
            let dry = this.StarterDry + this.Flour
            wet / dry

    let Components(starter, starterHydration, hydration, mass, evaporationCoefficient) =
        let starterDry = starter / (starterHydration + 1.0);
        let starterWet = (starterHydration * starter) / (starterHydration + 1.0);

        let flour = (mass - starterDry - (hydration * starterDry)) / (hydration + 1.0);
        let water = mass - starterDry - starterWet - flour;
        let salt = (mass * evaporationCoefficient) / 100.0;
    
        {
        Starter = starter;
        StarterHydration = starterHydration;
        Water = water;
        Flour = flour;
        Salt = salt;
        }