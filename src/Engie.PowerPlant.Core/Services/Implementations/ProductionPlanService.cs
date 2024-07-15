using Engie.PowerPlant.Core.Entities;
using Engie.PowerPlant.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Engie.PowerPlant.Core.Services.Implementations
{
    public class ProductionPlanService(IPowerPlanCombinationGenerator powerPlanCombinationGenerator, ILogger<ProductionPlanService> logger,
        IProductionPlanGenerator productionPlanGenerator) : IProductionPlanService
    {
        public ProductionPlan FindCheapestPlan(List<Entities.PowerPlant> powerPlants, int load)
        {
            var powerPlanCombinations = powerPlanCombinationGenerator.GenerateWithoutRepetition(powerPlants);

            var cheapestPowerPlan = productionPlanGenerator.GetCheapestPowerPlan(powerPlanCombinations, load);

            if (cheapestPowerPlan == null)
            {
                return new();
            }

            AddTurnedOffPowerPlants(powerPlants, cheapestPowerPlan);

            return cheapestPowerPlan;
        }

        private static void AddTurnedOffPowerPlants(List<Entities.PowerPlant> powerPlants, ProductionPlan? cheapestPowerPlan)
        {
            var activePowerPlants = cheapestPowerPlan.Items.Select(x => x.Name).ToList();

            var turnedOffPowerPlants = powerPlants.Where(x => !activePowerPlants.Contains(x.Name)).OrderBy(x => x.CostPerMwh).Select(x => x.Name).ToList();

            turnedOffPowerPlants.ForEach(x => cheapestPowerPlan.Items.Add(new ProductionPlanItem(x)));
        }
    }
}
