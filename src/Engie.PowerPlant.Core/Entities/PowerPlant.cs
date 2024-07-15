namespace Engie.PowerPlant.Core.Entities
{
    public abstract class PowerPlant(string name, double pMin, double pMax, double costPerMwh)
    {
        public string Name { get; } = name;
        public double PMin { get; } = Floor(pMin);
        public double PMax { get; } = Floor(pMax);
        public double CostPerMwh { get; } = costPerMwh;

        internal static double Floor(double value)
        {
            return Math.Floor(value * 10) / 10;
        }
    }
}