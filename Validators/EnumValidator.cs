using validation_service.Models;

namespace validation_service.Validators
{
    internal class EnumValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if (validationConfiguration.Enumerations != null && validationConfiguration.Enumerations.Split(',').Contains(value))
                return string.Empty;
            else
                return $"Value: {value} not found in enumeration list: [{validationConfiguration.Enumerations}]";
        }
    }
}
