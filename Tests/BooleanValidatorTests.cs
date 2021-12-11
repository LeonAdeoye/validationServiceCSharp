using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class BooleanValidatorTests
{
    private readonly IValidator booleanValidator = new BooleanValidator();

    [Test]
    public void Validate_TrueInput_ReturnsEmptyString()
    {
        string result = booleanValidator.Validate("true", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void Validate_FalseInput_ReturnsEmptyString()
    {
        string result = booleanValidator.Validate("false", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void Validate_TRUEInput_ReturnsEmptyString()
    {
        string result = booleanValidator.Validate("TRUE", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void Validate_FALSEInput_ReturnsEmptyString()
    {
        string result = booleanValidator.Validate("FALSE", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsError()
    {
        string result = booleanValidator.Validate("", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual("The value: does not validate into a boolean", result);
    }

    public void Validate_InvalidInput_ReturnsError()
    {
        string result = booleanValidator.Validate("Horatio", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual("The value: Horatio does not validate into a boolean", result);
    }
}