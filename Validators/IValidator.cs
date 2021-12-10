using validation_service.Models;

namespace validation_service.Validators
{
    internal interface IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration);
    }
}
