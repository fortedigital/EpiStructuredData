using Newtonsoft.Json;

namespace EpiStructuredData.Models
{
    public class OrganizationStructuredData
    {
        [JsonProperty("@type")] public string Type => "Organization";
        [JsonProperty("name")] public string Name { get; set; }
    }
}