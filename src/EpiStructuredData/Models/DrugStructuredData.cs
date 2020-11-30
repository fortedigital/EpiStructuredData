using Newtonsoft.Json;

namespace EpiStructuredData.Models
{
    public class DrugStructuredData
    {
        [JsonProperty("@context")] public string Context => "https://schema.org/";
        [JsonProperty("@type")] public string Type => "Drug";
        [JsonProperty("activeIngredient")] public string ActiveIngredient { get; set; }
        [JsonProperty("breastfeedingWarning")] public string BreastfeedingWarning { get; set; }
        [JsonProperty("dosageForm")] public string DosageForm { get; set; }
        [JsonProperty("drugClass")] public string DrugClass { get; set; }
        [JsonProperty("drugUnit")] public string DrugUnit { get; set; }
        [JsonProperty("labelDetails")] public string LabelDetails { get; set; }
        [JsonProperty("warning")] public string Warning { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("identifier")] public string Identifier { get; set; }
        [JsonProperty("image")] public string[] Image { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("prescriptionStatus")] public string PrescriptionStatus { get; set; }
    }
}