using System.Net;
using Moq;
using NUnit.Framework;
using validation_service.Controllers;
using validation_service.Models;
using validation_service.Services;
using System.Text.Json;

namespace validation_service.Tests;

[TestFixture]
public class ValidationControllerTests
{
    [SetUp]
    public void ReInitializeTest()
    {
    }

    [TearDown]
    public void DisposeTest()
    {
    }

    [Test]
    public void PostValidate_ValidArguments_ValidateMethodCalled()
    {
        // A Mock can be:
        // Instructed => you can tell a mock that if a certain method is called then it can answer with a certain response
        // Verified => verification is something you carry out after your production code has been called.You carry this out to verify that a certain method has been called with specific arguments
        var loggerMock = new Mock<ILogger<ValidationServiceController>>();
        var validationServiceMock = new Mock<IValidationService>();
        // To instruct a Mock object we use the method Setup().
        // We can use explicit arguments or general arguments using the It helper which allows you to instruct the method with any values of a certain data type.
        validationServiceMock.Setup(vsm => vsm.Validate(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<char>(), new ValidationConfiguration[1])).Returns(new List<string>());

        // There's an Object property on the Mock that represents the concrete implementation of the mock that we want to pass to our method.
        var validationServiceController = new ValidationServiceController(loggerMock.Object, validationServiceMock.Object);
        // Act
        var result = validationServiceController.Post(new ValidationRequest
        {
            Delimiter = '|',
            FilePath = "Horatio.csv", 
            HasHeader = false, 
            Validations = new ValidationConfiguration[1]
        });

        validationServiceMock.Verify(vsm => vsm.Validate("Horatio.csv", false, '|', new ValidationConfiguration[1]), Times.Once);
        Assert.AreEqual(JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(new List<string>())), result);
    }

    [Test]
    public void PostValidate_InvalidFileName_ValidateMethodNeverCalled()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ValidationServiceController>>();
        var validationServiceMock = new Mock<IValidationService>();
        var validationServiceController = new ValidationServiceController(loggerMock.Object, validationServiceMock.Object);
        // Act
        var result = validationServiceController.Post(new ValidationRequest
        {
            Delimiter = '|',
            FilePath = "",
            HasHeader = false,
            Validations = new ValidationConfiguration[1]
        });
        // Assert
        validationServiceMock.Verify(vsm => vsm.Validate("", false, '|', new ValidationConfiguration[1]), Times.Never);
        Assert.AreEqual(JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(new List<string> {"FilePath is invalid"})), result);
    }

    [Test]
    public void PostValidate_InvalidValidations_ValidateMethodNeverCalled()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ValidationServiceController>>();
        var validationServiceMock = new Mock<IValidationService>();
        var validationServiceController = new ValidationServiceController(loggerMock.Object, validationServiceMock.Object);
        // Act
        var result = validationServiceController.Post(new ValidationRequest
        {
            Delimiter = '|',
            FilePath = "Horatio.csv",
            HasHeader = false,
            Validations = null
        });
        // Assert
        validationServiceMock.Verify(vsm => vsm.Validate("Horatio.csv", false, '|', null), Times.Never);
        Assert.AreEqual(JsonSerializer.Serialize<ValidationResponse>(new ValidationResponse(new List<string> { "Validations cannot be NULL" })), result);
    }
}