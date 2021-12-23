using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class RangeValidatorTests
{
    private readonly IValidator rangeValidator = new RangeValidator();

    [Test]
    public void Validate_ValidInput_ReturnsEmptyString()
    {
        var result = rangeValidator.Validate("5", new Models.ValidationConfiguration { Type = "range", ValidRange = new string[]{"1", "100"} });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_AboveLimitInput_ReturnsErrorString()
    {
        var result = rangeValidator.Validate("101", new Models.ValidationConfiguration { Type = "range", ValidRange = new string[] { "1", "100" } });
        Assert.AreEqual("Value: 101 is not within the range", result);
    }

    [Test]
    public void Validate_BelowLimitInput_ReturnsErrorString()
    {
        var result = rangeValidator.Validate("5", new Models.ValidationConfiguration { Type = "range", ValidRange = new string[] { "10", "20" } });
        Assert.AreEqual("Value: 5 is not within the range", result);
    }

    [Test]
    public void Validate_EmptyInput_ReturnsErrorString()
    {
        var result = rangeValidator.Validate("", new Models.ValidationConfiguration { Type = "range", ValidRange = new string[] { "1", "100" } });
        Assert.AreEqual("Value:  is not within the range", result);
    }

    [Test]
    public void Validate_InvalidInput_ReturnsErrorString()
    {
        var result = rangeValidator.Validate("Horatio", new Models.ValidationConfiguration { Type = "range", ValidRange = new string[] { "1", "100" } });
        Assert.AreEqual("Value: Horatio is not within the range", result);
    }
}