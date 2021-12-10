using validation_service.Models;
using validation_service.Validators;

namespace validation_service.Services
{
    public class ValidationService : IValidationService
    {
        private readonly List<string> _listOfErrors;
        private readonly ValidatorFactory _validatorFactory;
        public ValidationService()
        {
            _validatorFactory = new();
            _listOfErrors = new();
        }

        public List<string> Validate(string fileName)
        {
            return _listOfErrors;
        }

        public List<String> ValidateRow(string[] columnValues, ValidationConfiguration[] validationConfigurations)
        {
            List<string> listOfErrors = new();
            for (int columnIndex = 0; columnIndex < columnValues.Length; columnIndex++)
            {

            }
            return listOfErrors;
        }

        private string ValidateColumn(string value, ValidationConfiguration validationConfiguration)
        {
            IValidator? validator = _validatorFactory.getInstance(validationConfiguration.Type);
            return validator.validate(value, validationConfiguration);
        }

        private string EnrichErrorWithLocation(int rowIndex, int columnIndex, string error)
        {
            return String.Format("Validation error at row [{0}] and column [{1}]: {2} ", rowIndex, columnIndex, error);
        }
    }
}
