using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using validation_service.Models;
using validation_service.Services;

namespace validation_service.Controllers;

[ApiController]
[Route("validate")]
public class ValidationServiceController : ControllerBase
{
    private readonly ILogger<ValidationServiceController> logger;
    private readonly IValidationService validationService;

    public ValidationServiceController(ILogger<ValidationServiceController> logger)
    {
        this.logger = logger;
        validationService = new ValidationService();
    }

    [HttpPost(Name = "PostValidate")]
    public string Post(ValidationRequest validationRequest)
    {
        List<string> errors = new();

        if (validationRequest.FilePath is null or "")
        {
            logger.LogError("FilePath is invalid");
            errors.Add("FilePath is invalid");
            return JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(errors));
        }

        errors.AddRange(validationService.Validate(validationRequest.FilePath, validationRequest.HasHeader, validationRequest.Delimiter, new ValidationConfiguration[5]
        {
            new ValidationConfiguration
            {
                Id = 0,
                Description = "Leon",
                Type = "string",
                CanBeEmpty = true,
            },
            new ValidationConfiguration
            {
                Id = 1,
                Description = "Jane",
                Type = "boolean",
                CanBeEmpty = false
            },
            new ValidationConfiguration
            {
                Id = 2,
                Description = "Harper",
                Type = "integer",
                CanBeEmpty = false
            },
            new ValidationConfiguration
            {
                Id = 3,
                Description = "Harper",
                Type = "integer",
                CanBeEmpty = false
            },
            new ValidationConfiguration
            {
                Id = 4,
                Description = "Harper",
                Type = "integer",
                CanBeEmpty = false
            }
        }));

        return JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(errors));
    }
}
