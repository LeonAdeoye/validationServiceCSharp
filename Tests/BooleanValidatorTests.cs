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
        var result = booleanValidator.Validate("true", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_FalseInput_ReturnsEmptyString()
    {
        var result = booleanValidator.Validate("false", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_TRUEInput_ReturnsEmptyString()
    {
        var result = booleanValidator.Validate("TRUE", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_FALSEInput_ReturnsEmptyString()
    {
        var result = booleanValidator.Validate("FALSE", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsError()
    {
        var result = booleanValidator.Validate("", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual("Cannot validate value:  as a boolean.", result);
    }

    public void Validate_InvalidInput_ReturnsError()
    {
        var result = booleanValidator.Validate("Horatio", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual("Cannot validate value: Horatio as a boolean.", result);
    }
}