using System.Text.RegularExpressions;
using validation_service.Models;

namespace validation_service.Validators
{
    internal class DecimalValidator : IValidator
    {
        private readonly Regex decimalRegex = new("^[0-9]+(\\.[0-9]+)?$");
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if (decimalRegex.IsMatch(value))
                return String.Empty;
            else
                return String.Format("The value: {0} cannot be validated as a decimal", value);
        }
    }
}
