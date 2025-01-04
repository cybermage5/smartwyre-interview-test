using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests.Services.IncentiveCalculators;

[TestClass]
public class FixedCashAmountCalculatorTests
{
    [TestMethod]
    public void CalculateRebate_ValidRequest_ReturnsTrue()
    {
        // Arrange
        var calculator = new FixedCashAmountCalculator();
        var rebate = new Rebate { Amount = 100m };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        var request = new CalculateRebateRequest();

        // Act
        var result = calculator.TryCalculate(request, rebate, product, out var rebateAmount);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(100m, rebateAmount);
    }

    [TestMethod]
    public void CalculateRebate_InvalidRebate_ReturnsFalse()
    {
        // Arrange
        var calculator = new FixedCashAmountCalculator();
        var rebate = new Rebate { Amount = 0 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        var request = new CalculateRebateRequest();

        // Act
        var result = calculator.TryCalculate(request, rebate, product, out var rebateAmount);

        // Assert
        Assert.IsFalse(result);
    }
}

