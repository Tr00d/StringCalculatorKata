namespace StringCalculator.Kata;

public record CalculationContext(IEnumerable<int> Numbers, char Separator)
{
    public static CalculationContext FromSeparator(char separator) => new(Enumerable.Empty<int>(), separator);

    public IEnumerable<int> GetNegativeNumbers() => this.Numbers.Where(IsNumberNegative);

    private static bool IsNumberNegative(int number) => number < 0;

    public int CalculateAmount() =>
        this.HasNegativeNumbers()
            ? throw NegativeNumbersException.FromCalculationContext(this)
            : this.Numbers.Sum();

    private bool HasNegativeNumbers() => this.GetNegativeNumbers().Any();

    public CalculationContext AppendLine(CalculationLine line) =>
        line.IsFirstLine() && line.IsDelimiterOverriden()
            ? this with { Separator = line.GetOverridenSeparator() }
            : this with { Numbers = this.Numbers.Concat(line.CalculateLine(this.Separator)) };
}