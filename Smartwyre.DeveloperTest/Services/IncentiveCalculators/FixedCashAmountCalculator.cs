using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators;

public class FixedCashAmountCalculator : IIncentiveCalculator
    {
        public bool TryCalculate(CalculateRebateRequest request, Rebate rebate, Product product, out decimal rebateAmount)
        {
            rebateAmount = 0;

            if (rebate == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) || rebate.Amount <= 0)
                return false;

            rebateAmount = rebate.Amount;
            return true;
        }
    }