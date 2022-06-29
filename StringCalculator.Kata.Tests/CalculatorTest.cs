using FluentAssertions;
using Xunit;

namespace StringCalculator.Kata.Tests;

public class CalculatorTest
{
    private readonly Calculator calculator;

    public CalculatorTest()
    {
        this.calculator = new Calculator();
    }

    [Fact(DisplayName = "Should return 0 given empty string")]
    public void ShouldReturnZero_GivenEmptyString() => this.calculator.Add(string.Empty).Should().Be(0);

    [Theory(DisplayName = "Should return value given single number")]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void ShouldReturnValue_GivenSingleNumber(string numbers, int number) =>
        this.calculator.Add(numbers).Should().Be(number);

    [Theory(DisplayName = "Should return sum given two numbers")]
    [InlineData("1,2", 3)]
    [InlineData("2,3", 5)]
    public void ShouldReturnSum_GivenTwoNumbers(string numbers, int number) =>
        this.calculator.Add(numbers).Should().Be(number);

    [Theory(DisplayName = "Should return sum given three numbers")]
    [InlineData("1,2,3", 6)]
    [InlineData("2,3,4", 9)]
    public void ShouldReturnSum_GivenThreeNumbers(string numbers, int number) =>
        this.calculator.Add(numbers).Should().Be(number);

    [Theory(DisplayName = "Should return sum given new line is used as separator")]
    [InlineData("1,2\n3", 6)]
    [InlineData("1,2\n3,4\n5", 15)]
    public void ShouldReturnSum_GivenNewLineSeparator(string numbers, int number) =>
        this.calculator.Add(numbers).Should().Be(number);

    [Theory(DisplayName = "Should return sum given different delimiter")]
    [InlineData("//;\n1;2", 3)]
    public void ShouldReturnSum_GivenDefaultSeparatorIsChanged(string numbers, int number) =>
        this.calculator.Add(numbers).Should().Be(number);

    [Theory(DisplayName = "Should throw exception given number is negative")]
    [InlineData("-1,2", "Negatives not allowed", new[] { -1 })]
    [InlineData("-1,-2", "Negatives not allowed", new[] { -1, -2 })]
    public void ShouldThrowException_GivenNumberIsNegative(string numbers, string message, int[] negativeNumbers)
    {
        Action act = () => this.calculator.Add(numbers);
        act
            .Should()
            .Throw<NegativeNumbersException>()
            .WithMessage(message)
            .Which.NegativeNumbers.Should().BeEquivalentTo(negativeNumbers);
    }

    [Theory(DisplayName = "Should return sum given numbers above threshold are ignored")]
    [InlineData("2,1001,1000", 1002)]
    public void ShouldReturnSum_GivenNumbersAboveThresholdAreIgnored(string numbers, int number) =>
        this.calculator.Add(numbers).Should().Be(number);

    [Theory(DisplayName = "Should return sum given delimiter has multiple characters")]
    [InlineData("//[***]\n1***2***3***4", 10)]
    public void ShouldReturnSum_GivenDelimiterHasMultipleCharacters(string numbers, int number) =>
        this.calculator.Add(numbers).Should().Be(number);
}