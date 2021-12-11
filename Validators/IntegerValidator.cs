using validation_service.Models;

namespace validation_service.Validators
{
    internal class IntegerValidator : IValidator
    {
        public string Validate(String value, ValidationConfiguration validationConfiguration)
        {
            bool result = int.TryParse(value, out _);
            if (!result)
                return "Cannot validate value: " + value + " as an integer.";
            return String.Empty;
        }
    }
}
