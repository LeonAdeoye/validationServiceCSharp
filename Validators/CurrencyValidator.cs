using System.Text.RegularExpressions;
using validation_service.Models;

namespace validation_service.Validators
{
    internal class CurrencyValidator : IValidator
    {
        private readonly Regex currencyRegex = new("^[A-Z]{3}$");
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            return currencyRegex.IsMatch(value) ? string.Empty : $"The value: {value} cannot be validated as a currency";
        }
    }
}
