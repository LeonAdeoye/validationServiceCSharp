using System.Text.Json.Serialization;

namespace validation_service.Models
{
    public record ValidationConfiguration
    {
        [JsonPropertyName("id")]
        public int Id
        {
            get;
            set;
        }
        [JsonPropertyName("canBeEmpty")]
        public bool CanBeEmpty
        {
            get;
            set;
        }
        [JsonPropertyName("stringFormat")]
        public string? StringFormat
        {
            get;
            set;
        }
        [JsonPropertyName("description")]
        public string? Description
        {
            get;
            set;
        }
        [JsonPropertyName("type")]
        public string? Type
        {
            get;
            set;
        }
        [JsonPropertyName("enumerations")]
        public string? Enumerations
        {
            get;
            set;
        }
        [JsonPropertyName("validRange")]
        public string[]? ValidRange
        {
            get;
            set;
        }
        [JsonPropertyName("regexValue")]
        public string? RegexValue
        {
            get;
            set;
        }
        [JsonPropertyName("nestedMatches")]
        public string[]? NestedMatches
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"ValidationConfiguration=\nId:{Id},\nDescription:{Description},\nCanBeEmpty:{CanBeEmpty},\nType:{Type}\n";
        }
    }
}