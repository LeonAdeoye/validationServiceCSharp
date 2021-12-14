using System.Text.RegularExpressions;
using validation_service.Models;

namespace validation_service.Validators
{
    internal class RegexValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if(validationConfiguration.RegexValue == null)
                return string.Empty;

            Regex regex = new(validationConfiguration.RegexValue);
            return regex.IsMatch(value) ? string.Empty : $"The value: {value} does not match regex: {validationConfiguration.RegexValue}";
        }
    }
}
