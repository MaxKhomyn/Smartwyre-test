using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var rebateStore = new RebateDataStore();
        var productStore = new ProductDataStore();

        IRebateService service = new RebateService(rebateStore, productStore);

        var request = new CalculateRebateRequest();

        service.Calculate(request);
    }
}
