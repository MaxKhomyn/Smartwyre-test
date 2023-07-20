using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public sealed class ProductDataStore : IProductDataStore
{
    public Product GetProduct(string identifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Product();
    }
}
