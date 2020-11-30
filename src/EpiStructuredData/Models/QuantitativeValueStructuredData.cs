using Newtonsoft.Json;

namespace EpiStructuredData.Models
{
    public class QuantitativeValueStructuredData
    {
        [JsonProperty("@type")] public string Type => "QuantitativeValue";
        [JsonProperty("unitCode")] public string UnitCode { get; set; }
        [JsonProperty("unitText")] public string UnitText { get; set; }
        [JsonProperty("value")] public double Value { get; set; }

        public static QuantitativeValueStructuredData Cm(double value)
        {
            return new QuantitativeValueStructuredData {Value = value, UnitCode = "CMT", UnitText = "cm"};
        }
    }
}