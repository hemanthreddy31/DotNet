using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Xunit;

namespace XUnitTests;

public class CalculatorControllerUnitTests
{
    private readonly CalculatorController _controller = new();

    [Fact(DisplayName = "Add returns correct sum")] 
    public void Add_ReturnsExpectedSum()
    {
        var actionResult = _controller.Add(2, 3);
        var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Equal(5d, ok.Value);
    }

    [Theory(DisplayName = "Subtract works for multiple cases")]
    [InlineData(5, 3, 2)]
    [InlineData(0, 10, -10)]
    [InlineData(-2, -3, 1)]
    public void Subtract_ReturnsExpected(double x, double y, double expected)
    {
        var actionResult = _controller.Subtract(x, y);
        var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Equal(expected, ok.Value);
    }

    public static IEnumerable<object[]> MultiplyData => new List<object[]>
    {
        new object[] { 2d, 3d, 6d },
        new object[] { -4d, 5d, -20d },
        new object[] { 0d, 100d, 0d }
    };

    [Theory(DisplayName = "Multiply using MemberData")]
    [MemberData(nameof(MultiplyData))]
    public void Multiply_ReturnsExpected(double x, double y, double expected)
    {
        var actionResult = _controller.Multiply(x, y);
        var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Equal(expected, ok.Value);
    }

    [Fact(DisplayName = "Divide by zero returns BadRequest")]
    public void Divide_ByZero_ReturnsBadRequest()
    {
        var actionResult = _controller.Divide(10, 0);
        Assert.IsType<BadRequestObjectResult>(actionResult.Result);
    }

    [Theory(DisplayName = "Divide returns correct quotient")]
    [InlineData(10, 2, 5)]
    [InlineData(9, 3, 3)]
    public void Divide_ReturnsExpected(double x, double y, double expected)
    {
        var actionResult = _controller.Divide(x, y);
        var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Equal(expected, ok.Value);
    }
} 