using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class EnumValidatorTests
{
    private readonly IValidator enumValidator = new EnumValidator();

    [Test]
    public void Validate_ValidInput_ReturnsEmptyString()
    {
        var result = enumValidator.Validate("Horatio", new Models.ValidationConfiguration { Type = "Enum", Enumerations = "Horatio,Harper" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_InvalidInput_ReturnsErrorString()
    {
        var result = enumValidator.Validate("Saori", new Models.ValidationConfiguration { Type = "Enum", Enumerations = "Horatio,Harper" });
        Assert.AreEqual("Value: Saori not found in enumeration list: [Horatio,Harper]", result);
    }

    [Test]
    public void Validate_InvalidEnumerations_ReturnsErrorString()
    {
        var result = enumValidator.Validate("Saori", new Models.ValidationConfiguration { Type = "Enum", Enumerations = "" });
        Assert.AreEqual("Value: Saori not found in enumeration list: []", result);
    }

    [Test]
    public void Validate_InvalidValue_ReturnsErrorString()
    {
        var result = enumValidator.Validate("", new Models.ValidationConfiguration { Type = "Enum", Enumerations = "Harper, Horatio" });
        Assert.AreEqual("Value:  not found in enumeration list: [Harper, Horatio]", result);
    }

}