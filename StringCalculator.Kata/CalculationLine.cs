namespace StringCalculator.Kata;

public record CalculationLine(int Index, string Value)
{
    private const string DelimiterOverride = "//";

    public bool IsFirstLine() => this.Index == default;

    public bool IsDelimiterOverriden() => this.Value.StartsWith(DelimiterOverride);

    public string GetOverridenSeparator()
    {
        string delimiter = this.Value.Replace(DelimiterOverride, string.Empty);
        return delimiter.Length > 1
            ? GetCustomDelimiter(delimiter)
            : delimiter;
    }

    private static string GetCustomDelimiter(string delimiter) => delimiter.Substring(1, delimiter.Length - 2);

    public IEnumerable<int> CalculateLine(string separator) =>
        this.Value
            .Split(separator)
            .Select(value => int.TryParse(value, out int number) ? number : default);
}