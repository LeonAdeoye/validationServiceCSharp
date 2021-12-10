using Microsoft.AspNetCore.Mvc;
using validation_service.Models;
using validation_service.Services;

namespace validation_service.Controllers;

[ApiController]
[Route("validate")]
public class ValidationServiceController : ControllerBase
{
    private readonly ILogger<ValidationServiceController> _logger;
    private readonly IValidationService _validationService;

    public ValidationServiceController(ILogger<ValidationServiceController> logger)
    {
        _logger = logger;
        _validationService = new ValidationService();
    }

    [HttpPost(Name = "PostValidate")]
    public IEnumerable<string> Post(string fileName)
    {
        List<string> errors = new();

        if(fileName == null || fileName == "")
        {
            _logger.LogError("Filename is invalid");
            errors.Add("filename is invalid");
            return errors;
        }

        errors.AddRange(_validationService.Validate(fileName, new ValidationConfiguration[3]
        {
            new ValidationConfiguration
            {
                Id = 0,
                Description = "Leon",
                Type = "string"
            },
            new ValidationConfiguration
            {
                Id = 1,
                Description = "Jane",
                Type = "boolean"
            },
            new ValidationConfiguration
            {
                Id = 2,
                Description = "Harper",
                Type = "integer"
            }
        }));

        return errors;
    }
}
