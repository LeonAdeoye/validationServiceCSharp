using validation_service.Models;

namespace validation_service.Services
{
    public interface IValidationService
    {
        IEnumerable<string> Validate(string fileName, ValidationConfiguration[] validationConfigurations);
        IEnumerable<string> ValidateRow(int rowIndex, string[] columnValues, ValidationConfiguration[] validationConfigurations);
    }
}