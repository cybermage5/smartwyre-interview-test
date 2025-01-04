using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests.Services;

[TestClass]
public class RebateServiceTests
{
    [TestMethod]
    public void Calculate_ValidRequest_ReturnsSuccess()
    {
        // Arrange
        var mockRebateDataStore = new Mock<IRebateDataStore>();
        var mockProductDataStore = new Mock<IProductDataStore>();
        var calculatorFactory = new IncentiveCalculatorFactory();

        mockRebateDataStore.Setup(x => x.GetRebate(It.IsAny<string>()))
                           .Returns(new Rebate
                           {
                               Incentive = IncentiveType.FixedCashAmount,
                               Amount = 100m
                           });

        mockProductDataStore.Setup(x => x.GetProduct(It.IsAny<string>()))
                            .Returns(new Product
                            {
                                SupportedIncentives = SupportedIncentiveType.FixedCashAmount
                            });

        var rebateService = new RebateService(mockRebateDataStore.Object, mockProductDataStore.Object, calculatorFactory);
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "REB001",
            ProductIdentifier = "PROD001",
            Volume = 10
        };

        // Act
        var result = rebateService.Calculate(request);

        // Assert
        Assert.IsTrue(result.Success);
    }

    [TestMethod]
    public void Calculate_InvalidRebate_ReturnsFailure()
    {
        // Arrange
        var mockRebateDataStore = new Mock<IRebateDataStore>();
        var mockProductDataStore = new Mock<IProductDataStore>();
        var calculatorFactory = new IncentiveCalculatorFactory();

        mockRebateDataStore.Setup(x => x.GetRebate(It.IsAny<string>())).Returns((Rebate)null);

        var rebateService = new RebateService(mockRebateDataStore.Object, mockProductDataStore.Object, calculatorFactory);
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "REB001",
            ProductIdentifier = "PROD001",
            Volume = 10
        };

        // Act
        var result = rebateService.Calculate(request);

        // Assert
        Assert.IsFalse(result.Success);
    }
}

