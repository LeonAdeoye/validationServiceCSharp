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
    private readonly HttpClient client = new();
    private HttpResponseMessage response;
    private const string ServiceBaseURL = "http://localhost:20099/";

    [SetUp]
    public void ReInitializeTest()
    {
        client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
    }

    [Test]
    public void GetAllProductsTest()
    {
        var validationServiceController = new ValidationServiceController()
        {
            Request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(ServiceBaseURL + "validate")
            }
        };
        validationServiceController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

        response = validationServiceController.Get();

        var responseResult = JsonConvert.DeserializeObject<List<string>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        Assert.AreEqual(responseResult.Any(), true);
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