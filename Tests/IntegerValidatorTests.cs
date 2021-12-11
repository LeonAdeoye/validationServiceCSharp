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
        string result = integerValidator.Validate("5559", new Models.ValidationConfiguration { Type = "integer" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void Validate_InvalidInput_ReturnsErrorString()
    {
        string result = integerValidator.Validate("TRUE", new Models.ValidationConfiguration { Type = "integer" });
        Assert.AreEqual("The value: TRUE does not validate into an integer", result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsErrorString()
    {
        string result = integerValidator.Validate("", new Models.ValidationConfiguration { Type = "integer" });
        Assert.AreEqual("The value: does not validate into an integer", result);
    }
}