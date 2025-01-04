using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators;

public interface IIncentiveCalculator
{
    bool TryCalculate(CalculateRebateRequest request, Rebate rebate, Product product, out decimal rebateAmount);
}
