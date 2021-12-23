using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class DecimalValidatorTests
{
    private readonly IValidator decimalValidator = new DecimalValidator();

    [Test]
    public void Validate_ValidIntegerInput_ReturnsEmptyString()
    {
        var result = decimalValidator.Validate("5559", new Models.ValidationConfiguration { Type = "decimal" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_ValidDecimalInput_ReturnsErrorString()
    {
        var result = decimalValidator.Validate("55.59", new Models.ValidationConfiguration { Type = "decimal" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsErrorString()
    {
        var result = decimalValidator.Validate("", new Models.ValidationConfiguration { Type = "decimal" });
        Assert.AreEqual("The value:  cannot be validated as a decimal", result);
    }

    [Test]
    public void Validate_InvalidInput_ReturnsErrorString()
    {
        var result = decimalValidator.Validate("Horatio", new Models.ValidationConfiguration { Type = "decimal" });
        Assert.AreEqual("The value: Horatio cannot be validated as a decimal", result);
    }
}