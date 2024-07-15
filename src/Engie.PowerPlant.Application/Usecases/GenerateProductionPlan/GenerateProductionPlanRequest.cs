using MediatR;
using System.Text.Json.Serialization;

namespace Engie.PowerPlant.Application.Usecases.GenerateProductionPlan
{
    public class GenerateProductionPlanRequest : IRequest<List<GenerateProductionPlanResponse>>
    {
        [JsonPropertyName("load")]
        public int Load { get; set; }

        [JsonPropertyName("fuels")]
        public Fuels Fuels { get; set; }

        [JsonPropertyName("powerplants")]
        public List<Powerplant> Powerplants { get; set; }
    }

    public class Fuels
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public double GasEuroMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public double KerosineEuroMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public int Co2EuroTon { get; set; }

        [JsonPropertyName("wind(%)")]
        public int Wind { get; set; }
    }

    public class Powerplant
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("efficiency")]
        public double Efficiency { get; set; }

        [JsonPropertyName("pmin")]
        public int Pmin { get; set; }

        [JsonPropertyName("pmax")]
        public double Pmax { get; set; }
    }

}
