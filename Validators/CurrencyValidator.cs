using System.Text.RegularExpressions;
using validation_service.Models;

namespace validation_service.Validators
{
    internal class CurrencyValidator : IValidator
    {
        private readonly Regex currencyRegex = new("^[A-Z]{3}$");
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if (currencyRegex.IsMatch(value))
                return String.Empty;
            else
                return String.Format("The value: {0} cannot be validated as a currency", value);
        }
    }
}
