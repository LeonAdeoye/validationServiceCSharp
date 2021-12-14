using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class CurrencyValidatorTests
{
    private readonly IValidator currencyValidator = new CurrencyValidator();

    [Test]
    public void Validate_ValidInput_ReturnsEmptyString()
    {
        var result = currencyValidator.Validate("GBP", new Models.ValidationConfiguration { Type = "currency" });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_NumberInput_ReturnsErrorString()
    {
        var result = currencyValidator.Validate("1122", new Models.ValidationConfiguration { Type = "currency" });
        Assert.AreEqual("The value: 1122 cannot be validated as a currency", result);
    }

    [Test]
    public void Validate_ShortInput_ReturnsErrorString()
    {
        var result = currencyValidator.Validate("GB", new Models.ValidationConfiguration { Type = "currency" });
        Assert.AreEqual("The value: GB cannot be validated as a currency", result);
    }

    [Test]
    public void Validate_LongInput_ReturnsErrorString()
    {
        var result = currencyValidator.Validate("GBPP", new Models.ValidationConfiguration { Type = "currency" });
        Assert.AreEqual("The value: GBPP cannot be validated as a currency", result);
    }
}