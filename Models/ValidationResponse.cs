using System.Text;
using System.Text.Json.Serialization;

namespace validation_service.Models
{
    public record ValidationResponse
    {
        private readonly List<string> errors;
        private readonly string result;

        public ValidationResponse(List<string> errors)
        {
            this.errors = errors;
            result = errors.Count == 0 ? "SUCCESS" : "FAILURE";
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (var index = 0; index < errors.Count; ++index)
            {
                sb.AppendFormat($"\"{errors[index]}\"");
                if (index < errors.Count - 1)
                    sb.Append(", ");
            }
            return $"{{\"RESULT\": \"{result}\", \"ERRORS\": [{sb}]}}";
        }
    }
}