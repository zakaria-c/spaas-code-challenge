namespace Engie.PowerPlant.Core.Entities
{
    public class WindturbinePowerPlant : PowerPlant
    {
        public WindturbinePowerPlant(string name, double pMax, int windPercentage)
            : base(name, pMax * windPercentage / (double)100, pMax * windPercentage / (double)100, 0)
        {

        }
    }
}