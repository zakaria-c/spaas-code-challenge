using Engie.PowerPlant.Application.Usecases.GenerateProductionPlan;
using Engie.PowerPlant.Core.Entities;
using System.ComponentModel;

namespace Engie.PowerPlant.Application.Mappings
{
    public class Mapper : IMapper
    {
        public List<Core.Entities.PowerPlant> Map(GenerateProductionPlanRequest request)
        {
            var powerPlants = new List<Core.Entities.PowerPlant>(request.Powerplants.Count);

            foreach (var item in request.Powerplants)
            {
                Core.Entities.PowerPlant powerPlant = item.Type switch
                {
                    "gasfired" => new GasfiredPowerPlant(item.Name, item.Efficiency, item.Pmin, item.Pmax, request.Fuels.GasEuroMWh),
                    "turbojet" => new TurbojetPowerPlant(item.Name, item.Efficiency, item.Pmin, item.Pmax, request.Fuels.KerosineEuroMWh),
                    "windturbine" => new WindturbinePowerPlant(item.Name, item.Pmax, request.Fuels.Wind),
                    _ => throw new InvalidEnumArgumentException(item.Type)
                };
                powerPlants.Add(powerPlant);
            }
            return powerPlants;
        }

        List<GenerateProductionPlanResponse> IMapper.Map(ProductionPlan productionPlan)
        {
            return productionPlan.Items.Select(x => new GenerateProductionPlanResponse
            {
                Name = x.Name,
                P = x.Power
            }).ToList();
        }
    }
}
