using validation_service.Models;
using validation_service.Validators;
using static System.Threading.Thread;

namespace validation_service.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ValidatorFactory validatorFactory;
        private readonly EmptyValidator emptyValidator;

        public ValidationService()
        {
            validatorFactory = new();
            emptyValidator = new();
        }

        public IEnumerable<string> Validate(string fileName, bool hasHeader, char delimiter, ValidationConfiguration[] validationConfigurations)
        {
            List<string> errors = new();

            Parallel.ForEach(File.ReadLines(fileName), (row, _, rowIndex) =>
            {
                if(!hasHeader || rowIndex != 0)
                    errors.AddRange(ValidateRow(rowIndex, row.Split(delimiter), validationConfigurations.OrderBy(x => x.Id).ToArray()));
            });

            return errors;
        }

        public IEnumerable<string> ValidateRow(long rowIndex, string[] columnValues, ValidationConfiguration[] validationConfigurations)
        {
            List<string> listOfErrors = new();

            if (columnValues.Length != validationConfigurations.Length)
            {
                listOfErrors.Add($"The number of column values does not match the number of validation configurations at row: {rowIndex}");
                return listOfErrors;
            }

            for (var columnIndex = 0; columnIndex < columnValues.Length; columnIndex++)
            {
                for (var configurationIndex = columnIndex; configurationIndex < validationConfigurations.Length; configurationIndex++)
                {
                    var currentValidationConfiguration = validationConfigurations[configurationIndex];
                    if (columnIndex == currentValidationConfiguration.Id)
                    {
                        Console.WriteLine($"Validating columnIndex: {columnIndex} using configurationIndex: {configurationIndex} using thread with ID: {CurrentThread.ManagedThreadId}");
                        var value = columnValues[columnIndex];
                        var error = emptyValidator.Validate(value, currentValidationConfiguration);

                        if (error == string.Empty && value == string.Empty)
                            continue;

                        if (error != string.Empty)
                            listOfErrors.Add(PrefixErrorWithLocation(rowIndex, columnIndex, error));

                        error = ValidateColumn(value, currentValidationConfiguration);
                        if (error != string.Empty)
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
            if (validationConfiguration.Type == null)
                return string.Empty;

            var validator = validatorFactory.GetInstance(validationConfiguration.Type);
            return validator != null ? validator.Validate(value, validationConfiguration) : $"Validator for type {validationConfiguration.Type} not found";
        }

        private static string PrefixErrorWithLocation(long rowIndex, int columnIndex, string error)
        {
            return $"Validation error at row: {rowIndex} and column: {columnIndex} => {error}";
        }
    }
}
