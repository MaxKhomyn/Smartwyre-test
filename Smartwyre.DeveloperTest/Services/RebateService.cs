using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Exceptions;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Services;

public sealed class RebateService : IRebateService
{
    private IRebateDataStore _rebateStore;

    private IProductDataStore _productStore;

    private readonly IDictionary<IncentiveType, Func<CalculateRebateRequest, Rebate, decimal>> _incentives;

    public RebateService(IRebateDataStore rebateStore, IProductDataStore productStore)
    {
        _rebateStore = rebateStore;
        _productStore = productStore;

        _incentives = new Dictionary<IncentiveType, Func<CalculateRebateRequest, Rebate, decimal>>()
        {
            {IncentiveType.FixedCashAmount, CalculateFixedCashAmount},
            {IncentiveType.FixedRateRebate, CalculateFixedRateRebate},
            {IncentiveType.AmountPerUom,CalculateAmountPerUom},
        };
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        try
        {
            var rebate = GetRebate(request.RebateIdentifier);

            if (!_incentives.ContainsKey(rebate.Incentive))
                throw new IncentiveException("Handler for such Incentive has not found.");

            var amount = _incentives[rebate.Incentive](request, rebate);

            _rebateStore.StoreCalculationResult(rebate, amount);

            return new(amount);
        }
        catch (Exception exception)
        {
            return new(exception.Message);
        }
    }

    private Rebate GetRebate(string identifier) =>
        _rebateStore.GetRebate(identifier) ??
            throw new RebateNotFoundException($"Rebate with Identifier - {identifier} has not found.");

    private Product GetProduct(string identifier) =>
        _productStore.GetProduct(identifier) ??
            throw new ProductNotFoundException($"Product with Identifier - {identifier} has not found.");

    private void ValidateNumbers(Dictionary<string, decimal> numbers) => numbers
        .Select(x => x.Value <= 0 ? throw new NumberException($"{nameof(x.Key)} is less or equal to zero.") : x);

    private decimal CalculateFixedCashAmount(CalculateRebateRequest request, Rebate rebate)
    {
        var product = GetProduct(request.ProductIdentifier);

        if (!product.ValidateSupportedIncentives(SupportedIncentiveType.FixedCashAmount))
            throw new SupportedIncentivesTypeNotFoundException($"{nameof(product.SupportedIncentives)} of product should contain {SupportedIncentiveType.FixedCashAmount}");

        var numbers = new Dictionary<string, decimal>()
        {
            { nameof(rebate.Amount), rebate.Amount },
        };

        ValidateNumbers(numbers);

        return rebate.Amount;
    }

    private decimal CalculateFixedRateRebate(CalculateRebateRequest request, Rebate rebate)
    {
        var product = GetProduct(request.ProductIdentifier);

        var amount = 0m;

        if (!product.ValidateSupportedIncentives(SupportedIncentiveType.FixedRateRebate))
            throw new SupportedIncentivesTypeNotFoundException($"{nameof(product.SupportedIncentives)} of product should contain {SupportedIncentiveType.FixedRateRebate}");

        var numbers = new Dictionary<string, decimal>()
        {
            { nameof(rebate.Amount), rebate.Amount },
            { nameof(rebate.Percentage), rebate.Percentage },
            { nameof(product.Price), product.Price },
            { nameof(request.Volume), request.Volume },
        };

        ValidateNumbers(numbers);

        return amount + product.Price * rebate.Percentage * request.Volume;
    }

    private decimal CalculateAmountPerUom(CalculateRebateRequest request, Rebate rebate)
    {
        var product = GetProduct(request.ProductIdentifier);

        var amount = 0m;

        if (!product.ValidateSupportedIncentives(SupportedIncentiveType.AmountPerUom))
            throw new SupportedIncentivesTypeNotFoundException($"{nameof(product.SupportedIncentives)} of product should contain {SupportedIncentiveType.AmountPerUom}");

        var numbers = new Dictionary<string, decimal>()
        {
            { nameof(rebate.Amount), rebate.Amount },
            { nameof(rebate.Percentage), rebate.Percentage },
            { nameof(request.Volume), request.Volume },
        };

        ValidateNumbers(numbers);

        return amount + rebate.Amount * request.Volume;
    }
}
