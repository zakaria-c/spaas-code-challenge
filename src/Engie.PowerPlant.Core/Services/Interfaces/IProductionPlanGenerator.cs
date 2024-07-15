using Engie.PowerPlant.Core.Entities;

namespace Engie.PowerPlant.Core.Services.Interfaces
{
    public interface IProductionPlanGenerator
    {
        ProductionPlan? GetCheapestPowerPlan(List<List<Entities.PowerPlant>> allCombinations, int load);
    }
}
