using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class IntegerValidatorTests
{
    private readonly IValidator integerValidator = new IntegerValidator();

    [Test]
    public void Validate_ValidInput_ReturnsEmptyString()
    {
        var result = integerValidator.Validate("5559", new Models.ValidationConfiguration { Type = "integer" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_InvalidInput_ReturnsErrorString()
    {
        var result = integerValidator.Validate("TRUE", new Models.ValidationConfiguration { Type = "integer" });
        Assert.AreEqual("Cannot validate value: TRUE as an integer.", result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsErrorString()
    {
        var result = integerValidator.Validate("", new Models.ValidationConfiguration { Type = "integer" });
        Assert.AreEqual("Cannot validate value:  as an integer.", result);
    }
}