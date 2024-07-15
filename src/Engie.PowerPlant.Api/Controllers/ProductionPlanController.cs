using Engie.PowerPlant.Application.Usecases.GenerateProductionPlan;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Engie.PowerPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController(IMediator mediator, IValidator<GenerateProductionPlanRequest> validator) : ControllerBase
    {
        [HttpPost]
        [Route("Generate")]
        [ProducesResponseType<List<GenerateProductionPlanResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType<IDictionary<string, string[]>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Generate(GenerateProductionPlanRequest request)
        {
            var result = await validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                return BadRequest(result.ToDictionary());
            }

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
