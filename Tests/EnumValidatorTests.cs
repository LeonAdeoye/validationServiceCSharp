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
        Assert.AreEqual(result = "Value Saori not found in enumeration list: [Horatio,Harper]", result);
    }

}