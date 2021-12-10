using validation_service.Models;

namespace validation_service.Services
{
    public interface IValidationService
    {
        IEnumerable<string> Validate(string fileName);
        IEnumerable<string> ValidateRow(string[] columnValues, ValidationConfiguration[] validationConfigurations);
    }
}