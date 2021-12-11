using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class BooleanValidatorTests
{
    private readonly IValidator booleanValidator = new BooleanValidator();

    [Test]
    public void validate_TrueInput_ReturnsEmptyString()
    {
        string result = booleanValidator.validate("true", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void validate_FalseInput_ReturnsEmptyString()
    {
        string result = booleanValidator.validate("false", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void validate_TRUEInput_ReturnsEmptyString()
    {
        string result = booleanValidator.validate("TRUE", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void validate_FALSEInput_ReturnsEmptyString()
    {
        string result = booleanValidator.validate("FALSE", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual(String.Empty, result);
    }

    [Test]
    public void validate_EmptyInput_ReturnsEmptyString()
    {
        string result = booleanValidator.validate("", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual("The value: does not validate into a boolean", result);
    }

    public void validate_InvalidInput_ReturnsEmptyString()
    {
        string result = booleanValidator.validate("Horatio", new Models.ValidationConfiguration { Type = "boolean" });
        Assert.AreEqual("The value: Horatio does not validate into a boolean", result);
    }

}