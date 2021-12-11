using validation_service.Models;
using validation_service.Validators;

namespace validation_service.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ValidatorFactory _validatorFactory;
        private readonly EmptyValidator _emptyValidator;
        //private readonly ILogger<ValidationService> _logger;

        public ValidationService()
        {
            _validatorFactory = new();
            _emptyValidator = new();
        }

        public IEnumerable<string> Validate(string fileName, ValidationConfiguration[] validationConfigurations)
        {
            return ValidateRow(0, new string[5] {"Horatio", "", "", "", "Mike"}, validationConfigurations);
        }

        public IEnumerable<String> ValidateRow(int rowIndex, string[] columnValues, ValidationConfiguration[] validationConfigurations)
        {
            List<string> listOfErrors = new();
            for (int columnIndex = 0; columnIndex < columnValues.Length; columnIndex++)
            {
                for(int configurationIndex = columnIndex; configurationIndex < validationConfigurations.Length; configurationIndex++)
                {
                    ValidationConfiguration currentValidationConfiguration = validationConfigurations[configurationIndex];
                    if (columnIndex == currentValidationConfiguration.Id)
                    {
                        Console.WriteLine(String.Format("Validating columnIndex: {0} using configurationIndex: {1}", columnIndex, configurationIndex));
                        string value = columnValues[columnIndex];
                        string error = _emptyValidator.validate(value, currentValidationConfiguration);
                        
                        if(error == "" && value == "")
                            continue;

                        if (error != "")
                            listOfErrors.Add(PrefixErrorWithLocation(rowIndex, columnIndex, error));

                        error = ValidateColumn(value, currentValidationConfiguration);
                        if (error != "")
                            listOfErrors.Add(PrefixErrorWithLocation(rowIndex, columnIndex, error));
                    }
                    else
                        break;
                }
            }
            return listOfErrors;
        }

        private string ValidateColumn(string value, ValidationConfiguration validationConfiguration)
        {
            IValidator? validator = _validatorFactory.getInstance(validationConfiguration.Type);
            if (validator != null)
                return validator.validate(value, validationConfiguration);
            else
                return String.Format("Validator for type {0} not found", validationConfiguration.Type);
        }

        private static string PrefixErrorWithLocation(int rowIndex, int columnIndex, string error)
        {
            return String.Format("Validation error at row: {0} and column: {1} => {2} ", rowIndex, columnIndex, error);
        }
    }
}
