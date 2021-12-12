using System.Text.RegularExpressions;
using validation_service.Models;

namespace validation_service.Validators
{
    internal class StringValidator : IValidator
    {  
        private readonly Regex upperCaseRegex = new("^[0-9A-Z\\W]*$");
        private readonly Regex lowerCaseRegex = new("^[0-9a-z\\W]*$");
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if (value == null || validationConfiguration.StringFormat is null or "") 
                return string.Empty;

            switch (validationConfiguration.StringFormat)
            {
                case "UPPERCASE" when !upperCaseRegex.IsMatch(value):
                    return "Cannot validate value: " + value + " as a uppercase string.";
                case "LOWERCASE" when !lowerCaseRegex.IsMatch(value):
                    return "Cannot validate value: " + value + " as a lowercase string.";
            }
            return string.Empty;
        }
    }
}
