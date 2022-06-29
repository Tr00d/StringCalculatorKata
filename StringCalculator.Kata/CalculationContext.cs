﻿namespace StringCalculator.Kata;

public record CalculationContext(IEnumerable<int> Numbers, char Separator)
{
    private const int Threshold = 1000;
    public static CalculationContext FromSeparator(char separator) => new(Enumerable.Empty<int>(), separator);

    public IEnumerable<int> GetNegativeNumbers() => this.Numbers.Where(IsNumberNegative);

    private static bool IsNumberNegative(int number) => number < 0;

    public int CalculateAmount() =>
        this.HasNegativeNumbers()
            ? throw NegativeNumbersException.FromCalculationContext(this)
            : this.GetValidNumbers().Sum();

    private IEnumerable<int> GetValidNumbers() => this.Numbers.Where(number => number <= Threshold);

    private bool HasNegativeNumbers() => this.GetNegativeNumbers().Any();

    public CalculationContext AppendLine(CalculationLine line) =>
        line.IsFirstLine() && line.IsDelimiterOverriden()
            ? this with { Separator = line.GetOverridenSeparator() }
            : this with { Numbers = this.Numbers.Concat(line.CalculateLine(this.Separator)) };
}