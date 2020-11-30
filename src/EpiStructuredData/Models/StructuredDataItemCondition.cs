using System.Runtime.Serialization;

namespace EpiStructuredData.Models
{
    public enum StructuredDataItemCondition
    {
        [EnumMember(Value = "https://schema.org/NewCondition")]
        NewCondition,
        [EnumMember(Value = "https://schema.org/UsedCondition")]
        UsedCondition,
        [EnumMember(Value = "https://schema.org/DamagedCondition")]
        DamagedCondition,
        [EnumMember(Value = "https://schema.org/RefurbishedCondition")]
        RefurbishedCondition,
    }
}