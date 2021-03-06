using validation_service.Models;
using validation_service.Validators;
using static System.Threading.Thread;
using System.Linq;

namespace validation_service.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IValidatorFactory validatorFactory;
        private readonly EmptyValidator emptyValidator;
        private readonly ILogger<ValidationService> logger;

        public ValidationService(IValidatorFactory validatorFactory, EmptyValidator emptyValidator, ILogger<ValidationService> logger) =>
            (this.validatorFactory, this.emptyValidator, this.logger) = (validatorFactory, emptyValidator, logger);

        public IEnumerable<string> Validate(string fileName, bool hasHeader, char delimiter, ValidationConfiguration[] validationConfigurations)
        {
            List<string> errors = new();

            logger.LogInformation($"Reading lines from file: {fileName}");

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
                LogAllErrors(listOfErrors);
                return listOfErrors;
            }

            for (var columnIndex = 0; columnIndex < columnValues.Length; columnIndex++)
            {
                for (var configurationIndex = columnIndex; configurationIndex < validationConfigurations.Length; configurationIndex++)
                {
                    var currentValidationConfiguration = validationConfigurations[configurationIndex];
                    if (columnIndex == currentValidationConfiguration.Id)
                    {
                        logger.LogDebug($"Validating columnIndex: {columnIndex} using configurationIndex: {configurationIndex} using thread with ID: {CurrentThread.ManagedThreadId}");

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

            LogAllErrors(listOfErrors);
            return listOfErrors;
        }

        private void LogAllErrors(List<string> listOfErrors)
        {
            listOfErrors.ForEach(error => logger.LogError(error));
        }

        private string ValidateColumn(string value, ValidationConfiguration validationConfiguration)
        {
            if (validationConfiguration.Type == null)
                return string.Empty;

            var validator = validatorFactory.GetValidator(validationConfiguration.Type);
            return validator != null ? validator.Validate(value, validationConfiguration) : $"Validator for type {validationConfiguration.Type} not found";
        }

        private static string PrefixErrorWithLocation(long rowIndex, int columnIndex, string error)
        {
            return $"Row: {rowIndex} and column: {columnIndex} has a validation error: {error}";
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
