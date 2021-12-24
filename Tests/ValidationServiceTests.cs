using NUnit.Framework;
using validation_service.Models;
using validation_service.Services;

namespace validation_service.Tests;

[TestFixture]
public class ValidationServiceTests
{
    private readonly IValidationService validationService = new ValidationService();

    [Test]
    public void ValidateRow_EmptyValidationConfigurations_ReturnsOneError()
    {
        var result = validationService.ValidateRow(0, new string[] {"Horatio", "Harper"}, new ValidationConfiguration[] {});
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("The number of column values does not match the number of validation configurations at row: 0", result.First());
    }

    [Test]
    public void ValidateRow_EmptyRow_ReturnsNoErrors()
    {
        var result = validationService.ValidateRow(0, new string[] {}, new ValidationConfiguration[] { });
        Assert.AreEqual(0, result.Count());
    }
}