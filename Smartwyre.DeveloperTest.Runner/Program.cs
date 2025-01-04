using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        // Set up dependencies
        var rebateDataStore = new RebateDataStore();
        var productDataStore = new ProductDataStore();
        var calculatorFactory = new IncentiveCalculatorFactory();

        // Create an instance of RebateService
        var rebateService = new RebateService(rebateDataStore, productDataStore, calculatorFactory);

        // Accept user input for Rebate Identifier
        Console.WriteLine("Enter Rebate Identifier:");
        var rebateIdentifier = Console.ReadLine();

        // Accept user input for Product Identifier
        Console.WriteLine("Enter Product Identifier:");
        var productIdentifier = Console.ReadLine();

        // Accept user input for Volume
        Console.WriteLine("Enter Volume:");
        if (!int.TryParse(Console.ReadLine(), out var volume))
        {
            Console.WriteLine("Invalid volume. Please enter a valid integer.");
            return;
        }

        // Prepare the CalculateRebateRequest
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = rebateIdentifier,
            ProductIdentifier = productIdentifier,
            Volume = volume
        };

        // Perform rebate calculation
        var result = rebateService.Calculate(request);

        // Output the result
        if (result.Success)
        {
            Console.WriteLine("Rebate calculation succeeded!");
        }
        else
        {
            Console.WriteLine("Rebate calculation failed.");
        }
    }
}
