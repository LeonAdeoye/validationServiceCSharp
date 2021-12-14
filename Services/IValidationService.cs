using validation_service.Models;

namespace validation_service.Services
{
    public interface IValidationService
    {
        IEnumerable<string> Validate(string fileName, bool hasHeader, char delimiter, ValidationConfiguration[] validationConfigurations);
        IEnumerable<string> ValidateRow(long rowIndex, string[] columnValues, ValidationConfiguration[] validationConfigurations);
    }
}