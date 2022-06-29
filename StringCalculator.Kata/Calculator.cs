namespace StringCalculator.Kata;

public class Calculator
{
    private const char MainSeparator = ',';
    private const char LineSeparator = '\n';

    public int Add(string numbers) =>
        numbers
            .Split(LineSeparator)
            .Select((line, index) => new CalculationLine(index, line))
            .Aggregate(CalculationContext.FromSeparator(MainSeparator), (context, line) => context.AppendLine(line))
            .CalculateAmount();
}