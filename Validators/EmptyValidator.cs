using validation_service.Models;

namespace validation_service.Validators
{
    internal class EmptyValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if (!validationConfiguration.CanBeEmpty && value == String.Empty)
                return "Value cannot be empty and yet it is";
            return String.Empty;

        }
    }
}
