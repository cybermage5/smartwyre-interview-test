# Smartwyre Developer Test Instructions

In the 'RebateService.cs' file you will find a method for calculating a rebate. At a high level the steps for calculating a rebate are:

 1. Lookup the rebate that the request is being made against.
 2. Lookup the product that the request is being made against.
 2. Check that the rebate and request are valid to calculate the incentive type rebate.
 3. Store the rebate calculation.

What we'd like you to do is refactor the code with the following things in mind:

 - Adherence to SOLID principles
 - Testability
 - Readability
 - Currently there are 3 known incentive types. In the future the business will want to add many more incentive types. Your solution should make it easy for developers to add new incentive types in the future.

We’d also like you to 
 - Add some unit tests to the Smartwyre.DeveloperTest.Tests project to show how you would test the code that you’ve produced 
 - Run the RebateService from the Smartwyre.DeveloperTest.Runner console application accepting inputs

The only specific 'rules' are:

- The solution should build
- The tests should all pass

You are free to use any frameworks/NuGet packages that you see fit. You should plan to spend around 1 hour completing the exercise.

## Solution

### Features
* Refactored RebateService: Follows the SOLID principles with a modular design.
* Extensible Incentive Types: Easy to add new incentive types using the Strategy Pattern.
* Unit Tests: Comprehensive test coverage for services and calculators using MSTest and Moq.

### Set Up Dependencies
1. Ensure the following dependencies are installed:

- .NET 8.0 SDK
- NuGet Packages:
    * MSTest (MSTest.TestFramework, MSTest.TestAdapter)
    * Moq

2. Restore dependencies:
```
dotnet restore
```

### How to Run
1. Navigate to the Runner Directory:
```
cd Smartwyre.DeveloperTest.Runner
```
2. Run the Program:
```
dotnet run
```

### How to Test
1: Navigate to the Test Project
```
cd Smartwyre.DeveloperTest.Tests
```
2. Run All Tests:
```
dotnet test
```

### Adding a New Incentive Type

To add a new incentive type:
1. Create a New Calculator:
- Place the implementation in Smartwyre.DeveloperTest/Services/IncentiveCalculators/.

2. Register in Factory:
- Update IncentiveCalculatorFactory.cs to include the new incentive type.

3. Test the New Calculator:
- Add tests in Smartwyre.DeveloperTest.Tests/Services/IncentiveCalculators/.


