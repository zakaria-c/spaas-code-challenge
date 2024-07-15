using Engie.PowerPlant.Application.Usecases.GenerateProductionPlan;
using Engie.PowerPlant.Core.Entities;

namespace Engie.PowerPlant.Application.Mappings
{
    public interface IMapper
    {
        List<Core.Entities.PowerPlant> Map(GenerateProductionPlanRequest request);
        List<GenerateProductionPlanResponse> Map(ProductionPlan productionPlan);
    }
}
