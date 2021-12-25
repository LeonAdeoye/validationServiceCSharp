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

    [Test]
    public void ValidateRow_MixedRows_ReturnsOneError()
    {
        var result = validationService.ValidateRow(0, new string[] { "HORATIO", "HARPER" }, new ValidationConfiguration[] 
            { 
                new ValidationConfiguration()
                {
                    Id = 0, 
                    Type = "string", 
                    StringFormat = "UPPERCASE"
                },
                new ValidationConfiguration()
                {
                    Id = 1,
                    Type = "string",
                    StringFormat = "LOWERCASE"
                }
            });
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Row: 0 and column: 1 has a validation error: Cannot validate value: HARPER as a lowercase string.", result.First());
    }

    [Test]
    public void ValidateRow_ValidRows_ReturnsNoErrors()
    {
        var result = validationService.ValidateRow(0, new string[] { "HORATIO", "harper" }, new ValidationConfiguration[]
        {
            new ValidationConfiguration()
            {
                Id = 0,
                Type = "string",
                StringFormat = "UPPERCASE"
            },
            new ValidationConfiguration()
            {
                Id = 1,
                Type = "string",
                StringFormat = "LOWERCASE"
            }
        });
        Assert.AreEqual(0, result.Count());
    }

    [Test]
    public void ValidateRow_ValidRow_ReturnsNoErrors()
    {
        var result = validationService.ValidateRow(0, new string[] { "horatio", "HARPER" }, new ValidationConfiguration[]
        {
            new ValidationConfiguration()
            {
                Id = 0,
                Type = "string",
                StringFormat = "UPPERCASE"
            },
            new ValidationConfiguration()
            {
                Id = 1,
                Type = "string",
                StringFormat = "LOWERCASE"
            }
        });
        Assert.AreEqual(2, result.Count());
        Assert.AreEqual("Row: 0 and column: 0 has a validation error: Cannot validate value: horatio as a uppercase string.", result.First());
        Assert.AreEqual("Row: 0 and column: 1 has a validation error: Cannot validate value: HARPER as a lowercase string.", result.Last());
    }
}