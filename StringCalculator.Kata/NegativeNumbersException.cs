namespace StringCalculator.Kata;

public class NegativeNumbersException : Exception
{
    private NegativeNumbersException(params int[] negativeNumbers)
        : base("Negatives not allowed")
    {
        this.NegativeNumbers = negativeNumbers;
    }

    public IEnumerable<int> NegativeNumbers { get; }

    public static NegativeNumbersException FromCalculationContext(CalculationContext context) =>
        new(context.GetNegativeNumbers().ToArray());
}