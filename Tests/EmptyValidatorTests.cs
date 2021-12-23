using NUnit.Framework;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class EmptyValidatorTests
{
    private readonly IValidator emptyValidator = new EmptyValidator();

    [Test]
    public void Validate_ValidEmptyInput_ReturnsEmptyString()
    {
        var result = emptyValidator.Validate("", new Models.ValidationConfiguration { Type = "string" , CanBeEmpty = true});
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_InvalidEmptyInput_ReturnsErrorString()
    {
        var result = emptyValidator.Validate("", new Models.ValidationConfiguration { Type = "string", CanBeEmpty = false });
        Assert.AreEqual("The value cannot be empty and yet it is.", result);
    }

    [Test]
    public void Validate_ValidNonEmptyInput_ReturnsEmptyString()
    {
        var result = emptyValidator.Validate("Horatio", new Models.ValidationConfiguration { Type = "string", CanBeEmpty = true });
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Validate_InvalidNonEmptyInput_ReturnsEmptyString()
    {
        var result = emptyValidator.Validate("Harper", new Models.ValidationConfiguration { Type = "string", CanBeEmpty = false });
        Assert.AreEqual(string.Empty, result);
    }
}