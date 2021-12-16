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

        if (string.IsNullOrEmpty(validationRequest.FilePath))
        {
            logger.LogError("FilePath is invalid");
            errors.Add("FilePath is invalid");
            return JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(errors));
        }

        if(validationRequest.Validations == null)
        {
            logger.LogError("Validations cannot be NULL");
            errors.Add("Validations cannot be NULL");
            return JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(errors));
        }

        errors.AddRange(validationService.Validate(validationRequest.FilePath, validationRequest.HasHeader,
            validationRequest.Delimiter, validationRequest.Validations));

        return JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(errors));
    }
}
