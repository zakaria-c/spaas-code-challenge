using System.Text.Json.Serialization;

namespace Engie.PowerPlant.Application.Usecases.GenerateProductionPlan
{
    public class GenerateProductionPlanResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("p")]
        public double P { get; set; }
    }

}
