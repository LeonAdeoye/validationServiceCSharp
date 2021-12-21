using validation_service.Models;

namespace validation_service.Validators
{
    public interface IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration);
    }
}
