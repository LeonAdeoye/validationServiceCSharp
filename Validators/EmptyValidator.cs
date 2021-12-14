using validation_service.Models;

namespace validation_service.Validators
{
    internal class EmptyValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            return (!validationConfiguration.CanBeEmpty && value == string.Empty) ? "Value cannot be empty and yet it is." : string.Empty;
        }
    }
}
