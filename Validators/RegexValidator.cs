using System.Text.RegularExpressions;
using validation_service.Models;

namespace validation_service.Validators
{
    internal class RegexValidator : IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration)
        {
            if(validationConfiguration.RegexValue == null)
                return String.Empty;

            Regex regex = new(validationConfiguration.RegexValue);
            if (regex.IsMatch(value))
                return String.Empty;
            else
                return String.Format("The value: {0} does not match regex: {1}", value, validationConfiguration.RegexValue);
        }
    }
}
