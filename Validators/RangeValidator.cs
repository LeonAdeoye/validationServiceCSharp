using validation_service.Models;
using static System.Int32;

namespace validation_service.Validators
{
    internal class RangeValidator : IValidator
    {
        public string Validate(string value, ValidationConfiguration validationConfiguration)
        {
            if(validationConfiguration.ValidRange is {Length: 2} 
               && TryParse(validationConfiguration.ValidRange[0], out int minValue) 
               && TryParse(validationConfiguration.ValidRange[1], out int maxValue) 
               && TryParse(value, out int actualValue) && actualValue >= minValue && actualValue <= maxValue)
                return string.Empty;

            return $"Value: {value} is not within the range";


        }
    }
}
