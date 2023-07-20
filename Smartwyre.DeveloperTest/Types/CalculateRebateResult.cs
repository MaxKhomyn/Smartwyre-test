namespace Smartwyre.DeveloperTest.Types;

public sealed class CalculateRebateResult
{
    public decimal Amount { get; set; } = 0m;

    public string ErrorMessage { get; set; } = string.Empty;

    public CalculateRebateResult(decimal amount, string errorMessage = "")
    {
        Amount = amount;
        ErrorMessage = errorMessage;
    }

    public CalculateRebateResult(string errorMessage, decimal amount = 0m)
    {
        ErrorMessage = errorMessage;
        Amount = amount;
    }
}
