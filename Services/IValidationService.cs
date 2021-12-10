using validation_service.Models;

namespace validation_service.Services
{
    public interface IValidationService
    {
        List<string> Validate(string fileName);
        List<string> ValidateRow(string[] columnValues, ValidationConfiguration[] validationConfigurations);
    }
}