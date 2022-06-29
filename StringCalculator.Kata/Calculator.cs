namespace StringCalculator.Kata;

public class Calculator
{
    private const char MainSeparator = ',';

    public int Add(string numbers) =>
        GetLines(numbers)
            .Aggregate(CalculationContext.FromSeparator(MainSeparator), (context, line) => context.AppendLine(line))
            .CalculateAmount();

    private static IEnumerable<CalculationLine> GetLines(string numbers) => numbers
        .Split('\n')
        .Select((line, index) => new CalculationLine(index, line));
}