using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests
{
    public static class RebateServiceScenarios
    {
        public static IEnumerable<object[]> Get()
        {
            yield return new object[]
            {
                new TestScenario
                {
                    Name = "Rebate has not found",
                    Rebate = null,
                    Product = null,
                    Request = new ()
                    {
                        ProductIdentifier = "ProductIdentifier",
                        RebateIdentifier = "RebateIdentifier",
                        Volume = 1,
                    },
                    Expected = new ("Rebate with Identifier - RebateIdentifier has not found."),
                },
            };

            yield return new object[]
            {
                new TestScenario
                {
                    Name = "Product has not found",
                    Rebate = new Rebate() { Identifier = "RebateIdentifier", Incentive = IncentiveType.FixedRateRebate },
                    Product = null,
                    Request = new ()
                    {
                        ProductIdentifier = "ProductIdentifier",
                        RebateIdentifier = "RebateIdentifier",
                        Volume = 1,
                    },
                    Expected = new ("Product with Identifier - ProductIdentifier has not found."),
                },
            };

            yield return new object[]
            {
                new TestScenario
                {
                    Name = "FixedCashAmount - has no SupportedIncentiveType.FixedRateRebate",
                    Rebate = new Rebate() { Identifier = "RebateIdentifier", Incentive = IncentiveType.FixedRateRebate },
                    Product = new Product() { Identifier = "ProductIdentifier", Price = 100, SupportedIncentives = SupportedIncentiveType.FixedCashAmount },
                    Request = new ()
                    {
                        ProductIdentifier = "ProductIdentifier",
                        RebateIdentifier = "RebateIdentifier",
                        Volume = 1,
                    },
                    Expected = new ("SupportedIncentives of product should contain FixedRateRebate"),
                },
            };

            yield return new object[]
            {
                new TestScenario
                {
                    Name = "FixedCashAmount - has no SupportedIncentiveType.FixedCashAmount",
                    Rebate = new Rebate() { Identifier = "RebateIdentifier", Incentive = IncentiveType.FixedCashAmount },
                    Product = new Product() { Identifier = "ProductIdentifier", Price = 100, SupportedIncentives = SupportedIncentiveType.FixedRateRebate },
                    Request = new ()
                    {
                        ProductIdentifier = "ProductIdentifier",
                        RebateIdentifier = "RebateIdentifier",
                        Volume = 1,
                    },
                    Expected = new ("SupportedIncentives of product should contain FixedCashAmount"),
                },
            };

            yield return new object[]
            {
                new TestScenario
                {
                    Name = "FixedCashAmount - has no SupportedIncentiveType.AmountPerUom",
                    Rebate = new Rebate() { Identifier = "RebateIdentifier", Incentive = IncentiveType.AmountPerUom },
                    Product = new Product() { Identifier = "ProductIdentifier", Price = 100, SupportedIncentives = SupportedIncentiveType.FixedCashAmount },
                    Request = new ()
                    {
                        ProductIdentifier = "ProductIdentifier",
                        RebateIdentifier = "RebateIdentifier",
                        Volume = 1,
                    },
                    Expected = new ("SupportedIncentives of product should contain AmountPerUom"),
                },
            };

            yield return new object[]
            {
                new TestScenario
                {
                    Name = "FixedCashAmount - has no SupportedIncentiveType.AmountPerUom",
                    Rebate = new Rebate() { Identifier = "RebateIdentifier", Incentive = IncentiveType.AmountPerUom },
                    Product = new Product() { Identifier = "ProductIdentifier", Price = 100, SupportedIncentives = SupportedIncentiveType.FixedCashAmount },
                    Request = new ()
                    {
                        ProductIdentifier = "ProductIdentifier",
                        RebateIdentifier = "RebateIdentifier",
                        Volume = 1,
                    },
                    Expected = new ("SupportedIncentives of product should contain AmountPerUom"),
                },
            };
        }
    }
}
