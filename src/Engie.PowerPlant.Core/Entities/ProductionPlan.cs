namespace Engie.PowerPlant.Core.Entities
{
    public class ProductionPlan
    {
        public double Cost { get; set; } = 0;
        public List<ProductionPlanItem> Items { get; set; } = [];
    }

    public class ProductionPlanItem(string name)
    {
        public string Name { get; set; } = name;
        public double Power { get; set; } = 0;
    }
}
