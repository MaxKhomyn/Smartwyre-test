using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public sealed class RebateDataStore : IRebateDataStore
{
    public Rebate GetRebate(string identifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Rebate() { Identifier = identifier };
    }

    public void StoreCalculationResult(Rebate account, decimal amount)
    {
        // Update account in database, code removed for brevity
    }
}
