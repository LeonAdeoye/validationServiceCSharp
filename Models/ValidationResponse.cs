using System.Text;
using System.Text.Json.Serialization;

namespace validation_service.Models
{
    public record ValidationResponse
    {
        [JsonInclude]
        public List<string> Errors;
        [JsonInclude]
        public string Result;

        public ValidationResponse(List<string> errors)
        {
            this.Errors = errors;
            Result = errors.Count == 0 ? "SUCCESS" : "FAILURE";
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (var index = 0; index < Errors.Count; ++index)
            {
                sb.AppendFormat($"\"{Errors[index]}\"");
                if (index < Errors.Count - 1)
                    sb.Append(", ");
            }
            return $"{{\"RESULT\": \"{Result}\", \"ERRORS\": [{sb}]}}";
        }
    }
}