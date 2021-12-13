


using System.Data;
using validation_service.Models;
using validation_service.Validators;

namespace validation_service.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ValidatorFactory validatorFactory;
        private readonly EmptyValidator emptyValidator;
        //private readonly ILogger<ValidationService> _logger;

        public ValidationService()
        {
            validatorFactory = new();
            emptyValidator = new();
        }

        private void LoadFile(string fileName)
        {
            // TODO load CSV file. @"D:\CSVFolder\CSVFile.csv"
            var csvTable = new DataTable();
            var csvReader = new CsvReader.CsvReader(new StreamReader(File.OpenRead(fileName)), true);
            csvTable.Load(csvReader);
        }


        public IEnumerable<string> Validate(string fileName, ValidationConfiguration[] validationConfigurations)
        {
            LoadFile(fileName);
            return ValidateRow(0, new string[5] {"Horatio", "", "", "", "Mike"}, validationConfigurations.OrderBy(x => x.Id).ToArray());
        }

        public IEnumerable<string> ValidateRow(int rowIndex, string[] columnValues, ValidationConfiguration[] validationConfigurations)
        {
            
            List<string> listOfErrors = new();
            for (var columnIndex = 0; columnIndex < columnValues.Length; columnIndex++)
            {
                for(var configurationIndex = columnIndex; configurationIndex < validationConfigurations.Length; configurationIndex++)
                {
                    var currentValidationConfiguration = validationConfigurations[configurationIndex];
                    if (columnIndex == currentValidationConfiguration.Id)
                    {
                        Console.WriteLine($"Validating columnIndex: {columnIndex} using configurationIndex: {configurationIndex}");
                        var value = columnValues[columnIndex];
                        var error = emptyValidator.Validate(value, currentValidationConfiguration);
                        
                        if(error == string.Empty && value == string.Empty)
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

        private static string PrefixErrorWithLocation(int rowIndex, int columnIndex, string error)
        {
            return $"Validation error at row: {rowIndex} and column: {columnIndex} => {error}";
        }
    }
}
