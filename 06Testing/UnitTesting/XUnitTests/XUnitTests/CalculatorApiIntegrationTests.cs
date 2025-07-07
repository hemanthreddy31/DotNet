using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace XUnitTests;

public class CalculatorApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CalculatorApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Theory(DisplayName = "Add endpoint returns expected result")]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    public async Task AddEndpoint_ReturnsExpected(double x, double y, double expected)
    {
        var response = await _client.GetAsync($"/api/calculator/add?x={x}&y={y}");
        response.EnsureSuccessStatusCode();
        var actual = await response.Content.ReadFromJsonAsync<double>();
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Divide by zero endpoint returns 400 BadRequest")]
    public async Task Divide_ByZero_ReturnsBadRequest()
    {
        var response = await _client.GetAsync("/api/calculator/divide?x=10&y=0");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
} 