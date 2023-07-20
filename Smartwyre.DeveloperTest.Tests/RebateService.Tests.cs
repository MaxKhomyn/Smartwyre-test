using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using System.Collections.Generic;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public sealed class RebateServiceTests
{
    public static IEnumerable<object[]> GetScenarios() => RebateServiceScenarios.Get();

    [Theory]
    [MemberData(nameof(GetScenarios))]
    public void Calculate(TestScenario scenario)
    {
        //Arrange
        var rebateStore = new Mock<IRebateDataStore>();

        rebateStore
            .Setup(x => x.GetRebate(scenario.Request.RebateIdentifier))
            .Returns(scenario.Rebate);

        var productStore = new Mock<IProductDataStore>();

        productStore
            .Setup(x => x.GetProduct(scenario.Request.ProductIdentifier))
            .Returns(scenario.Product);

        IRebateService service = new RebateService(rebateStore.Object, productStore.Object);

        //Act
        var result = service.Calculate(scenario.Request);

        //Assert
        Assert.Equivalent(result, scenario.Expected);
    }
}
