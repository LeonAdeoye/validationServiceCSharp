using validation_service.Models;

namespace validation_service.Validators
{
    internal class EnumValidator : IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration)
        {
            if(validationConfiguration.Enumerations != null && validationConfiguration.Enumerations.Split(',').Contains(value))
                return String.Empty;
            else
                return String.Format("Value {0} not found in enumeration list: {1}", value, validationConfiguration.Enumerations);
        }
    }
}
