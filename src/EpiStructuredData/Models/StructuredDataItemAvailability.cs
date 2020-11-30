using System.Runtime.Serialization;

namespace EpiStructuredData.Models
{
    public enum StructuredDataItemAvailability
    {
        [EnumMember(Value = "https://schema.org/InStock")]
        InStock,
        [EnumMember(Value = "https://schema.org/InStoreOnly")]
        InStoreOnly,
        [EnumMember(Value = "https://schema.org/OutOfStock")]
        OutOfStock
    }
}