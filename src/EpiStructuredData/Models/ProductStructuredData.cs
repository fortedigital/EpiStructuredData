using Newtonsoft.Json;

namespace EpiStructuredData.Models
{
    public class ProductStructuredData
    {
        [JsonProperty("@context")] public string Context => "https://schema.org/";
        [JsonProperty("@type")] public string Type => "Product";
        [JsonProperty("brand")] public BrandStructuredData Brand { get; set; }
        [JsonProperty("category")] public string Category { get; set; }
        [JsonProperty("color")] public string Color { get; set; }
        [JsonProperty("offers")] public OfferStructuredData Offers { get; set; }
        [JsonProperty("height")] public QuantitativeValueStructuredData Height { get; set; }
        [JsonProperty("width")] public QuantitativeValueStructuredData Width { get; set; }
        [JsonProperty("depth")] public QuantitativeValueStructuredData Depth { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("identifier")] public string Identifier { get; set; }
        [JsonProperty("image")] public string[] Image { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("sku")] public string Sku { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
    }
}