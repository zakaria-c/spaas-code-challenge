using Engie.PowerPlant.Core.Entities;
using Engie.PowerPlant.Core.Services.Interfaces;

namespace Engie.PowerPlant.Core.Services.Implementations
{
    public class ProductionPlanGenerator : IProductionPlanGenerator
    {
        public ProductionPlan? GetCheapestPowerPlan(List<List<Entities.PowerPlant>> allCombinations, int load)
        {
            var validCombination = new List<ProductionPlan>();

            foreach (var combination in allCombinations)
            {
                // Process conbination
                var productionPlan = ProcessCombination(combination, load);

                // Consider the combination in case it was returned
                if (productionPlan != null)
                {
                    validCombination.Add(productionPlan);
                }
            }

            return validCombination.OrderBy(x => x.Cost).FirstOrDefault();
        }

        private static ProductionPlan ProcessCombination(List<Entities.PowerPlant> combination, int load)
        {
            // Sort power plants by PMax in descending order
            var sortedPowerPlant = combination.OrderBy(pp => pp.CostPerMwh).ThenByDescending(x => x.PMax).ThenBy(x => x.Name).ToList();

            // Calculate the initial total power based on PMin
            var minTotalPower = sortedPowerPlant.Sum(pp => pp.PMin);

            // Discard if the total min power is greater than the requested load
            if (minTotalPower > load)
            {
                return null;
            }

            // Calculate the initial total power based on PMax
            var maxTotalPower = sortedPowerPlant.Sum(pp => pp.PMax);

            // Discard if the total max power is less than the requested load
            if (maxTotalPower < load)
            {
                return null;
            }

            // Calculate the remaining load to distribute
            var remainingLoad = load - minTotalPower;

            var productionPlan = new ProductionPlan();

            var totalCost = 0d;

            // Distribute the remaining load to the power plants in order
            foreach (var plant in sortedPowerPlant)
            {
                var productionPlanItem = new ProductionPlanItem(plant.Name);

                if (remainingLoad <= 0)
                {
                    productionPlanItem.Power = plant.PMin;
                }
                else
                {
                    var additionalPower = Entities.PowerPlant.Floor(Math.Min(remainingLoad, plant.PMax - plant.PMin));

                    remainingLoad -= additionalPower;

                    productionPlanItem.Power = plant.PMin + additionalPower;
                }

                productionPlan.Items.Add(productionPlanItem);

                productionPlan.Cost += productionPlanItem.Power * plant.CostPerMwh;
            }

            return productionPlan;
        }
    }
}
