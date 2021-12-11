using validation_service.Models;

namespace validation_service.Validators
{
    internal interface IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration);
    }
}
