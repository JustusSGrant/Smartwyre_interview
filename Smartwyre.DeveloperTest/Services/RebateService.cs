using System;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IProductDataStore _productDataStore;
    private readonly IRebateDataStore _rebateDataStore;

    public RebateService(IProductDataStore productDataStore, IRebateDataStore rebateDataStore)
    {
        _productDataStore = productDataStore ?? throw new ArgumentNullException(nameof(productDataStore));
        _rebateDataStore = rebateDataStore ?? throw new ArgumentNullException(nameof(rebateDataStore));
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        var product = _productDataStore.GetProduct(request.ProductIdentifier);
        var result = new CalculateRebateResult();
        var rebateAmount = 0m;
        result.Success = DetermineGeneralSuccesStatus(rebate, product);

        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                result.Success = result.Success
                    && product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount)
                    && rebate.Amount != 0m;

                rebateAmount = result.Success ? rebate.Amount : 0m;
                break;

            case IncentiveType.FixedRateRebate:
                result.Success = result.Success
                    && product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate)
                    && (rebate.Percentage != 0 && product.Price != 0 && request.Volume != 0);

                rebateAmount = result.Success
                    ? rebateAmount + product.Price * rebate.Percentage * request.Volume
                    : 0m;

                break;

            case IncentiveType.AmountPerUom:
                result.Success = result.Success
                    && product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom)
                    && (rebate.Amount != 0 && request.Volume != 0);
                rebateAmount = result.Success
                    ? rebateAmount + rebate.Amount * request.Volume
                    : 0m;

                break;
        }

        if (result.Success)
        {
            _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }

    private bool DetermineGeneralSuccesStatus(Rebate rebate, Product product)
    {
        return rebate != null && product != null;
    }
}
