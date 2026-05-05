using FluentAssertions;
using InterestRates.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace InterestRates.Tests.Controllers;

public class TaxaJurosControllerTests
{
    private readonly TaxaJurosController _controller;

    public TaxaJurosControllerTests()
    {
        _controller = new TaxaJurosController();
    }

    [Fact]
    public async Task Get_ShouldReturnDecimalValue()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().BeOfType(typeof(decimal));
    }

    [Fact]
    public async Task Get_ShouldReturnCorrectInterestRate()
    {
        // Arrange
        const decimal expectedRate = 0.01m;

        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().Be(expectedRate);
    }

    [Fact]
    public async Task Get_ShouldReturnOnePercent()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().Be(0.01m, "a taxa de juros deve ser 1%");
    }

    [Fact]
    public async Task Get_ShouldReturnPositiveValue()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().BePositive("a taxa de juros deve ser um valor positivo");
    }

    [Fact]
    public async Task Get_ShouldReturnValueGreaterThanZero()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Get_ShouldReturnValueLessThanOne()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().BeLessThan(1, "a taxa de juros deve ser menor que 100%");
    }

    [Fact]
    public async Task Get_ShouldReturnCompletedTask()
    {
        // Act
        var task = _controller.Get();

        // Assert
        task.Should().NotBeNull();
        task.IsCompleted.Should().BeTrue();
    }

    [Fact]
    public async Task Get_ShouldHaveCorrectDecimalPrecision()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().Be(0.01m);
        (result * 100).Should().Be(1m, "deve representar 1%");
    }

    [Fact]
    public void Controller_ShouldHaveApiControllerAttribute()
    {
        // Arrange
        var controllerType = typeof(TaxaJurosController);

        // Act
        var hasAttribute = controllerType.GetCustomAttributes(typeof(ApiControllerAttribute), false).Any();

        // Assert
        hasAttribute.Should().BeTrue("o controller deve ter o atributo ApiController");
    }

    [Fact]
    public void Controller_ShouldHaveRouteAttribute()
    {
        // Arrange
        var controllerType = typeof(TaxaJurosController);

        // Act
        var hasAttribute = controllerType.GetCustomAttributes(typeof(RouteAttribute), false).Any();

        // Assert
        hasAttribute.Should().BeTrue("o controller deve ter o atributo Route");
    }

    [Fact]
    public void Get_Method_ShouldHaveHttpGetAttribute()
    {
        // Arrange
        var method = typeof(TaxaJurosController).GetMethod("Get");

        // Act
        var hasAttribute = method?.GetCustomAttributes(typeof(HttpGetAttribute), false).Any();

        // Assert
        hasAttribute.Should().BeTrue("o método Get deve ter o atributo HttpGet");
    }

    [Fact]
    public void Get_Method_ShouldHaveProducesResponseTypeAttribute()
    {
        // Arrange
        var method = typeof(TaxaJurosController).GetMethod("Get");

        // Act
        var hasAttribute = method?.GetCustomAttributes(typeof(ProducesResponseTypeAttribute), false).Any();

        // Assert
        hasAttribute.Should().BeTrue("o método Get deve ter o atributo ProducesResponseType");
    }
}
