using Engie.PowerPlant.Core.Entities;

namespace Engie.PowerPlant.Core.Services.Interfaces
{
    public interface IProductionPlanService
    {
        ProductionPlan FindCheapestPlan(List<Entities.PowerPlant> powerPlants, int load);
    }
}
