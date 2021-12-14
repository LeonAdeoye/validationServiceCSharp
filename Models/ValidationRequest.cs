using System.Text.Json.Serialization;

namespace validation_service.Models
{
    public record ValidationRequest
    {
        [JsonPropertyName("filePath")]
        public string? FilePath
        {
            get;
            set;
        }
        [JsonPropertyName("delimiter")]
        public char Delimiter
        {
            get;
            set;
        }

        [JsonPropertyName("hasHeader")]
        public bool HasHeader
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"ValidationRequest=\nFilePath:{FilePath},\nDelimiter:{Delimiter},\nHasHeader:{HasHeader}";
        }
    }
}