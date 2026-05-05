using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace InterestRates.Tests.Integration;

public class TaxaJurosIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TaxaJurosIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetTaxaJuros_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/taxaJuros");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetTaxaJuros_ShouldReturnCorrectContentType()
    {
        // Act
        var response = await _client.GetAsync("/taxaJuros");

        // Assert
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }

    [Fact]
    public async Task GetTaxaJuros_ShouldReturnDecimalValue()
    {
        // Act
        var response = await _client.GetAsync("/taxaJuros");
        var result = await response.Content.ReadFromJsonAsync<decimal>();

        // Assert
        result.Should().BeOfType(typeof(decimal));
    }

    [Fact]
    public async Task GetTaxaJuros_ShouldReturnExpectedValue()
    {
        // Arrange
        const decimal expectedRate = 0.01m;

        // Act
        var response = await _client.GetAsync("/taxaJuros");
        var result = await response.Content.ReadFromJsonAsync<decimal>();

        // Assert
        result.Should().Be(expectedRate);
    }

    [Fact]
    public async Task GetTaxaJuros_ShouldReturnPositiveValue()
    {
        // Act
        var response = await _client.GetAsync("/taxaJuros");
        var result = await response.Content.ReadFromJsonAsync<decimal>();

        // Assert
        result.Should().BePositive();
    }

    [Fact]
    public async Task Swagger_ShouldBeAccessible()
    {
        // Act
        var response = await _client.GetAsync("/swagger/v1/swagger.json");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task SwaggerUI_ShouldBeAccessible()
    {
        // Act
        var response = await _client.GetAsync("/swagger/index.html");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetTaxaJuros_MultipleCalls_ShouldReturnConsistentValue()
    {
        // Arrange
        const int numberOfCalls = 5;
        var results = new List<decimal>();

        // Act
        for (int i = 0; i < numberOfCalls; i++)
        {
            var response = await _client.GetAsync("/taxaJuros");
            var result = await response.Content.ReadFromJsonAsync<decimal>();
            results.Add(result);
        }

        // Assert
        results.Should().OnlyContain(x => x == 0.01m, "todas as chamadas devem retornar o mesmo valor");
    }

    [Fact]
    public async Task GetTaxaJuros_ShouldCompleteQuickly()
    {
        // Arrange
        var startTime = DateTime.UtcNow;

        // Act
        var response = await _client.GetAsync("/taxaJuros");
        var endTime = DateTime.UtcNow;
        var duration = endTime - startTime;

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        duration.Should().BeLessThan(TimeSpan.FromSeconds(2), "a requisição deve ser rápida");
    }
}
