using validation_service.Models;

namespace validation_service.Validators
{
    internal class RangeValidator : IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration)
        {
            if (validationConfiguration.ValidRange.Length != 2)
                return string.Empty;

                var min = validationConfiguration.ValidRange[0];
                var max = validationConfiguration.ValidRange[1];

            return String.Empty;
        }
    }
}
