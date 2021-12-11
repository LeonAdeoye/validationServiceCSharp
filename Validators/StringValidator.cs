using System.Text.RegularExpressions;
using validation_service.Models;

namespace validation_service.Validators
{
    internal class StringValidator : IValidator
    {  
        private readonly Regex upperCaseRegex = new Regex("^[0-9A-Z\\W] *$");
        private readonly Regex lowerCaseRegex = new Regex("^[0-9a-z\\W] *$");
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if(value != null && validationConfiguration.StringFormat != null && validationConfiguration.StringFormat != String.Empty)
            {
                if (validationConfiguration.StringFormat == "UPPERCASE" && !upperCaseRegex.IsMatch(value))
                    return "Cannot validate value: " + value + " as a uppercase string.";

                if (validationConfiguration.StringFormat == "LOWERCASE" && !lowerCaseRegex.IsMatch(value))
                    return "Cannot validate value: " + value + " as a lowercase string.";
            }
            return String.Empty;
        }
    }
}
