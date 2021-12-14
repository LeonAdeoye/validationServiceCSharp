using validation_service.Models;

namespace validation_service.Validators
{
    internal class BooleanValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            var result = bool.TryParse(value, out _);
            return result ? string.Empty : $"Cannot validate value: {value} as a boolean.";
        }
    }
}
