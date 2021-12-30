using validation_service.Models;

namespace validation_service.Validators
{
    public class IntegerValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            return int.TryParse(value, out _) ? string.Empty : $"Cannot validate value: {value} as an integer.";
        }
    }
}
