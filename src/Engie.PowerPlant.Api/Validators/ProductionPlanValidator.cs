using Engie.PowerPlant.Application.Usecases.GenerateProductionPlan;
using FluentValidation;

namespace Engie.PowerPlant.Api.Validators
{
    public class ProductionPlanValidator : AbstractValidator<GenerateProductionPlanRequest>
    {
        private static List<string> PowerPlanTypes = new List<string>() { "windturbine", "turbojet", "gasfired" };
        public ProductionPlanValidator()
        {
            RuleFor(x => x.Powerplants).Must(list => list.Count > 0).WithMessage("No power plants were provided.");

            RuleFor(x => x.Powerplants).Must(list => list.DistinctBy(x => x.Name).Count() == list.Count).WithMessage("Power plants cannot have the same name.");

            RuleFor(x => x.Powerplants).Must(list => list.All(x => PowerPlanTypes.Contains(x.Type))).WithMessage("Power plant type has to be either windturbine, turbojet, or gasfired.");
        }
    }
}
