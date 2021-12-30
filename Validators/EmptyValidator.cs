using validation_service.Models;

namespace validation_service.Validators
{
    public class EmptyValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            return (!validationConfiguration.CanBeEmpty && value == string.Empty) ? "The value cannot be empty and yet it is." : string.Empty;
        }
    }
}
