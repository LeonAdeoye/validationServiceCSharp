using validation_service.Models;

namespace validation_service.Validators
{
    internal class EnumValidator : IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration)
        {
            return String.Empty;
        }
    }
}
