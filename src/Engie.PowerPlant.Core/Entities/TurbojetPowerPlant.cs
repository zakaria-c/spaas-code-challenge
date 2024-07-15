namespace Engie.PowerPlant.Core.Entities
{
    public class TurbojetPowerPlant(string name, double efficiency, double pMin, double pMax, double kerosinePrice)
        : PowerPlant(name, pMin, pMax, kerosinePrice / efficiency)
    {
    }
}