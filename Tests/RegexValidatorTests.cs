using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class RegexValidatorTests
{
    private readonly IValidator regexValidator = new RegexValidator();

    [Test]
    public void Validate_ValidInput_ReturnsEmptyString()
    {
        var result = regexValidator.Validate("5550", new Models.ValidationConfiguration { Type = "regex" , RegexValue = "^[0-9]+(\\.[0-9]+)?$" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_OtherValidInput_ReturnsEmptyString()
    {
        var result = regexValidator.Validate("550.30", new Models.ValidationConfiguration { Type = "regex", RegexValue = "^[0-9]+(\\.[0-9]+)?$" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_InvalidInput_ReturnsErrorString()
    {
        var result = regexValidator.Validate("Horatio", new Models.ValidationConfiguration { Type = "regex", RegexValue = "^[0-9]+(\\.[0-9]+)?$" });
        Assert.AreEqual("The value: Horatio does not match regex: ^[0-9]+(\\.[0-9]+)?$", result);
    }

}