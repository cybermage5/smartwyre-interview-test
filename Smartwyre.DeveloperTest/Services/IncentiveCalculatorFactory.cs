using System;
using System.Collections.Generic;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class IncentiveCalculatorFactory
{
    private readonly Dictionary<IncentiveType, IIncentiveCalculator> _calculators;

    public IncentiveCalculatorFactory()
    {
        _calculators = new Dictionary<IncentiveType, IIncentiveCalculator>
            {
                { IncentiveType.FixedCashAmount, new FixedCashAmountCalculator() },
                { IncentiveType.FixedRateRebate, new FixedRateRebateCalculator() },
                { IncentiveType.AmountPerUom, new AmountPerUomCalculator() }
            };
    }

    public IIncentiveCalculator GetCalculator(IncentiveType incentiveType)
    {
        if (!_calculators.TryGetValue(incentiveType, out var calculator))
            throw new NotSupportedException($"Incentive type {incentiveType} is not supported.");

        return calculator;
    }
}