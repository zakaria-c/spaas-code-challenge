namespace Engie.PowerPlant.Core.Services.Interfaces
{
    public interface IPowerPlanCombinationGenerator
    {
        List<List<T>> GenerateWithoutRepetition<T>(List<T> list);
    }
}
