namespace Engie.PowerPlant.Core.Entities
{
    public class GasfiredPowerPlant(string name, double efficiency, double pMin, double pMax, double gasPrice)
        : PowerPlant(name, pMin, pMax, gasPrice / efficiency)
    {

    }
}