using System.Net;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using validation_service.Controllers;
using validation_service.Services;
using validation_service.Validators;

namespace validation_service.Tests;

[TestFixture]
public class ValidationControllerTests
{
    private readonly ValidationService validationService = new();
    private HttpClient client;
    private HttpResponseMessage response;
    private const string ServiceBaseURL = "http://localhost:20099/";
    private ILogger<ValidationServiceController> logger;
    private HttpRequestMessage request;

    ValidationControllerTests(ILogger<ValidationServiceController> logger)
    {
        this.logger = logger;
    }

    [SetUp]
    public void ReInitializeTest()
    {
        client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
    }

    [Test]
    public void PostValidate()
    {

    }

    [TearDown]
    public void DisposeTest()
    {
        if (response != null)
            response.Dispose();

        if (client != null)
            client.Dispose();
    }

}