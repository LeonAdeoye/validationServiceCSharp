using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

public class StringValidatorTests
{
    private readonly IValidator stringValidator = new StringValidator();

    [Test]
    public void Validate_ValidInput_ReturnsEmptyString()
    {
        var result = stringValidator.Validate("HORATIO", new Models.ValidationConfiguration { Type = "string", StringFormat = "UPPERCASE"});
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_InvalidInput_ReturnsEmptyString()
    {
        var result = stringValidator.Validate("harper", new Models.ValidationConfiguration { Type = "string", StringFormat = "LOWERCASE" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsErrorString()
    {
        var result = stringValidator.Validate("", new Models.ValidationConfiguration { Type = "string" });
        Assert.AreEqual(string.Empty, result);
    }
}