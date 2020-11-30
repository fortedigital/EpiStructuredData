using Newtonsoft.Json;

namespace EpiStructuredData.Models
{
    public class OfferStructuredData
    {
        [JsonProperty("@type")] public string Type => "Offer";
        [JsonProperty("availability")] public StructuredDataItemAvailability Availability { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("category")] public string Category { get; set; }
        [JsonProperty("price")] public decimal Price { get; set; }
        [JsonProperty("priceCurrency")] public string PriceCurrency { get; set; }
        [JsonProperty("seller")] public OrganizationStructuredData Seller { get; set; }
        [JsonProperty("itemCondition")] public StructuredDataItemCondition ItemCondition { get; set; }
    }
}