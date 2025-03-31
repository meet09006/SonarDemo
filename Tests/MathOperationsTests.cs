using SonarDemo;
namespace Tests;

public class MathOperationsTests
{
    private readonly MathOperations _mathOperations;
    public MathOperationsTests()
    {
        _mathOperations = new MathOperations();
    }

    [Fact]
    public void Add_ShouldReturnCorrectResult()
    {
        var a = 4;
        var b = 5;
        var c = 9;

        var result = _mathOperations.Add(a, b);

        Assert.Equal(c, result);
    }

    [Fact]
    public void Subtract_ShouldReturnCorrectResult()
    {
        var a = 9;
        var b = 5;
        var c = 4;

        var result = _mathOperations.Subtract(a, b);

        Assert.Equal(c, result);
    }

    [Fact]
    public void Multiply_ShouldReturnCorrectResult()
    {
        var a = 9;
        var b = 5;
        var c = 45;

        var result = _mathOperations.Multiply(a, b);

        Assert.Equal(c, result);
    }

    [Fact]
    public void Divide_ShouldReturnCorrectQuotient()
    {
        int a = 6;
        int b = 2;

        // Act
        double result = _mathOperations.Divide(a, b);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
    {
        int a = 6;
        int b = 0;

        Assert.Throws<DivideByZeroException>(() => _mathOperations.Divide(a, b));
    }
}