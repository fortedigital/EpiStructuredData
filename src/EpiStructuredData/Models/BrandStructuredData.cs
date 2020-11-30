using Newtonsoft.Json;

namespace EpiStructuredData.Models
{
    public class BrandStructuredData
    {
        [JsonProperty("@type")] public string Type => "Brand";
        [JsonProperty("name")] public string Name { get; set; }
    }
}