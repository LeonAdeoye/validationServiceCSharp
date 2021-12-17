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
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(validationConfiguration.StringFormat)) 
                return string.Empty;

            return validationConfiguration.StringFormat switch
            {
                "UPPERCASE" when !upperCaseRegex.IsMatch(value) => $"Cannot validate value: {value} as a uppercase string.",
                "LOWERCASE" when !lowerCaseRegex.IsMatch(value) => $"Cannot validate value: {value} as a lowercase string.",
                _ => string.Empty
            };
        }
    }
}
