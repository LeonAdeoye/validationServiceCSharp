using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

public class StringValidatorTests
{
    private readonly IValidator stringValidator = new StringValidator();

    [Test]
    public void Validate_UppercaseInput_ReturnsEmptyString()
    {
        var result = stringValidator.Validate("HORATIO", new Models.ValidationConfiguration { Type = "string", StringFormat = "UPPERCASE"});
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_LowercaseInput_ReturnsEmptyString()
    {
        var result = stringValidator.Validate("harper", new Models.ValidationConfiguration { Type = "string", StringFormat = "LOWERCASE" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_InvalidUppercaseInput_ReturnsErrorString()
    {
        var result = stringValidator.Validate("harper", new Models.ValidationConfiguration { Type = "string", StringFormat = "UPPERCASE" });
        Assert.AreEqual("Cannot validate value: harper as a uppercase string.", result);
    }

    [Test]
    public void Validate_InvalidLowercaseInput_ReturnsErrorString()
    {
        var result = stringValidator.Validate("HORATIO", new Models.ValidationConfiguration { Type = "string", StringFormat = "LOWERCASE" });
        Assert.AreEqual("Cannot validate value: HORATIO as a lowercase string.", result);
    }

    [Test]
    public void Validate_MixedCaseInput_ReturnsErrorString()
    {
        var result = stringValidator.Validate("HORatio", new Models.ValidationConfiguration { Type = "string", StringFormat = "LOWERCASE" });
        Assert.AreEqual("Cannot validate value: HORatio as a lowercase string.", result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsEmptyString()
    {
        var result = stringValidator.Validate("", new Models.ValidationConfiguration { Type = "string" });
        Assert.AreEqual(string.Empty, result);
    }
}