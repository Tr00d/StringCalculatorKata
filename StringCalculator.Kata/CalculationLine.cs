namespace StringCalculator.Kata;

public record CalculationLine(int Index, string Value)
{
    private const string DelimiterOverride = "//";

    public bool IsFirstLine() => this.Index == default;

    public bool IsDelimiterOverriden() => this.Value.StartsWith(DelimiterOverride);

    public char GetOverridenSeparator() =>
        this.Value.Replace(DelimiterOverride, string.Empty)
            .ToCharArray()
            .First();

    public IEnumerable<int> CalculateLine(char separator) =>
        this.Value
            .Split(separator)
            .Select(value => int.TryParse(value, out int number) ? number : default);
}