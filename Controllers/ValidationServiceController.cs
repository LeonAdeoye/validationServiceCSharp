using Microsoft.AspNetCore.Mvc;
using validation_service.Services;

namespace validation_service.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidationServiceController : ControllerBase
{
    private readonly ILogger<ValidationServiceController> _logger;
    private readonly ValidationService _validationService;

    public ValidationServiceController(ILogger<ValidationServiceController> logger)
    {
        _logger = logger;
        _validationService = new();
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

        errors.AddRange(_validationService.Validate(fileName));

        return errors;
    }
}