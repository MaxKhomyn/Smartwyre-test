namespace Smartwyre.DeveloperTest.Types;

public sealed class Product
{
    public int Id { get; set; }
    public string Identifier { get; set; }
    public decimal Price { get; set; }
    public string Uom { get; set; }
    public SupportedIncentiveType SupportedIncentives { get; set; }

    public bool ValidateSupportedIncentives(SupportedIncentiveType type) =>
        SupportedIncentives.HasFlag(type);
}
