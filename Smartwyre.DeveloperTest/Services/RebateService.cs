using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
    {
        private readonly IRebateDataStore _rebateDataStore;
        private readonly IProductDataStore _productDataStore;
        private readonly IncentiveCalculatorFactory _calculatorFactory;

        public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore, IncentiveCalculatorFactory calculatorFactory)
        {
            _rebateDataStore = rebateDataStore;
            _productDataStore = productDataStore;
            _calculatorFactory = calculatorFactory;
        }

        public CalculateRebateResult Calculate(CalculateRebateRequest request)
        {
            var rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
            var product = _productDataStore.GetProduct(request.ProductIdentifier);

            if (rebate == null || product == null)
                return new CalculateRebateResult { Success = false };

            var calculator = _calculatorFactory.GetCalculator(rebate.Incentive);

            if (!calculator.TryCalculate(request, rebate, product, out var rebateAmount))
                return new CalculateRebateResult { Success = false };

            _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);

            return new CalculateRebateResult { Success = true };
        }
    }
