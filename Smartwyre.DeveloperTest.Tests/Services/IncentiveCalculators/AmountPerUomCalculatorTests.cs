using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests.Services.IncentiveCalculators;

[TestClass]
public class AmountPerUomCalculatorTests
{
    [TestMethod]
    public void CalculateRebate_ValidRequest_ReturnsTrue()
    {
        // Arrange
        var calculator = new AmountPerUomCalculator();
        var rebate = new Rebate { Amount = 20 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
        var request = new CalculateRebateRequest { Volume = 10 };

        // Act
        var result = calculator.TryCalculate(request, rebate, product, out var rebateAmount);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(200m, rebateAmount); // 20 * 10
    }

    [TestMethod]
    public void CalculateRebate_InvalidVolume_ReturnsFalse()
    {
        // Arrange
        var calculator = new AmountPerUomCalculator();
        var rebate = new Rebate { Amount = 20 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
        var request = new CalculateRebateRequest { Volume = 0 };

        // Act
        var result = calculator.TryCalculate(request, rebate, product, out var rebateAmount);

        // Assert
        Assert.IsFalse(result);
    }
}

