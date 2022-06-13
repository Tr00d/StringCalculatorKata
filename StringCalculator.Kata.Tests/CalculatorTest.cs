using FluentAssertions;

namespace StringCalculator.Kata.Tests;

public class CalculatorTest
{
    private readonly Calculator calculator;

    public CalculatorTest()
    {
        this.calculator = new Calculator();
    }

    [Fact]
    public void SomeFakeTest()
    {
        bool value = true;
        value.Should().BeTrue();
    }
}