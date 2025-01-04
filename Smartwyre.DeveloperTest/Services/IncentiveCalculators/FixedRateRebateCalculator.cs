using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators;

public class FixedRateRebateCalculator : IIncentiveCalculator
{
    public bool TryCalculate(CalculateRebateRequest request, Rebate rebate, Product product, out decimal rebateAmount)
    {
        rebateAmount = 0;

        if (rebate == null || product == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate) ||
            rebate.Percentage <= 0 || product.Price <= 0 || request.Volume <= 0)
            return false;

        rebateAmount = product.Price * (rebate.Percentage / 100) * request.Volume;
        return true;
    }
}