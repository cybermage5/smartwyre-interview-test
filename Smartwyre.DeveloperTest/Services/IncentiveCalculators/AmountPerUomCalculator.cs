using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators;

public class AmountPerUomCalculator : IIncentiveCalculator
{
    public bool TryCalculate(CalculateRebateRequest request, Rebate rebate, Product product, out decimal rebateAmount)
    {
        rebateAmount = 0;

        if (rebate == null || product == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom) ||
            rebate.Amount <= 0 || request.Volume <= 0)
            return false;

        rebateAmount = rebate.Amount * request.Volume;
        return true;
    }
}