using Engie.PowerPlant.Application.Mappings;
using Engie.PowerPlant.Core.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Engie.PowerPlant.Application.Usecases.GenerateProductionPlan
{
    public class GenerateProductionPlanRequestHandler(ILogger<GenerateProductionPlanRequestHandler> logger,
        IProductionPlanService productionPlan, IMapper mapper)
        : IRequestHandler<GenerateProductionPlanRequest, List<GenerateProductionPlanResponse>>
    {
        public Task<List<GenerateProductionPlanResponse>> Handle(GenerateProductionPlanRequest request, CancellationToken cancellationToken)
        {
            var powerPlants = mapper.Map(request);

            logger.LogInformation("Production plan generation is starting ...");

            var cheapestPowerPlan = productionPlan.FindCheapestPlan(powerPlants, request.Load);

            logger.LogInformation("Production plan has been generated ...");

            return Task.FromResult(mapper.Map(cheapestPowerPlan));
        }
    }
}
