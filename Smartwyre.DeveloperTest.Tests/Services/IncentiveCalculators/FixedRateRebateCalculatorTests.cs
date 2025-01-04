using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests.Services.IncentiveCalculators;

[TestClass]
public class FixedRateRebateCalculatorTests
{
    [TestMethod]
    public void CalculateRebate_ValidRequest_ReturnsTrue()
    {
        // Arrange
        var calculator = new FixedRateRebateCalculator();
        var rebate = new Rebate { Percentage = 10 }; // 10%
        var product = new Product { Price = 100, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
        var request = new CalculateRebateRequest { Volume = 5 };

        // Act
        var result = calculator.TryCalculate(request, rebate, product, out var rebateAmount);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(50m, rebateAmount); // Expected: 100 * 0.10 * 5 = 50
    }

    [TestMethod]
    public void CalculateRebate_InvalidRebate_ReturnsFalse()
    {
        // Arrange
        var calculator = new FixedRateRebateCalculator();
        var rebate = new Rebate { Percentage = 0 };
        var product = new Product { Price = 100, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
        var request = new CalculateRebateRequest { Volume = 5 };

        // Act
        var result = calculator.TryCalculate(request, rebate, product, out var rebateAmount);

        // Assert
        Assert.IsFalse(result);
    }
}

