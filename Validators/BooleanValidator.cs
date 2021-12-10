using validation_service.Models;

namespace validation_service.Validators
{
    internal class BooleanValidator : IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration)
        {
            bool result = bool.TryParse(value, out _);
            if (!result)
                return "Cannot validate value: " + value + " as a boolean.";
            return "";

        }
    }
}
