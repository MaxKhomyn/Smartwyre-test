using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests
{
    public sealed class TestScenario
    {
        public string Name { get; set; } = string.Empty;

        public CalculateRebateRequest Request { get; set; } = new CalculateRebateRequest();

        public Rebate Rebate { get; set; } = null;

        public Product Product { get; set; } = null;

        public CalculateRebateResult Expected { get; set; } = null;

        public override string ToString() =>
            Name ?? ToString();
    }
}
