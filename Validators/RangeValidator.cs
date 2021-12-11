using validation_service.Models;

namespace validation_service.Validators
{
    internal class RangeValidator : IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration)
        {
            if(validationConfiguration.ValidRange != null && validationConfiguration.ValidRange.Length == 2 &&
                Int32.TryParse(validationConfiguration.ValidRange[0], out int minValue) && 
                Int32.TryParse(validationConfiguration.ValidRange[1], out int maxValue) &&
                Int32.TryParse(value, out int actualValue) && actualValue >= minValue && actualValue <= maxValue)
                    return string.Empty;

                return String.Format("Value: {0} is not within the range", value);

            
        }
    }
}
