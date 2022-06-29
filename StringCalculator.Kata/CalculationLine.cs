namespace StringCalculator.Kata;

public record CalculationLine(int Index, string Value)
{
    private const string DelimiterOverride = "//";

    public bool IsFirstLine() => this.Index == default;

    public bool IsDelimiterOverriden() => this.Value.StartsWith(DelimiterOverride);

    public IEnumerable<string> GetCustomSeparators() =>
        this.Value
            .Replace(DelimiterOverride, string.Empty)
            .Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

    public IEnumerable<int> CalculateLine(IEnumerable<string> separators) =>
        this.Value
            .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(value => int.TryParse(value, out int number) ? number : default);
}