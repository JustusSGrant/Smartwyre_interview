using System;
using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Services;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Data;

namespace Smartwyre.DeveloperTest.Runner;

public static class Program
{

    static void Main(string[] args)
    {
        // setup DI
        var serviceProvider = new ServiceCollection()
            .AddScoped<IRebateService, RebateService>()
            .AddSingleton<IProductDataStore, ProductDataStore>()
            .AddSingleton<IRebateDataStore, RebateDataStore>()
            .BuildServiceProvider();
        CalculateRebate(serviceProvider);
    }

    private static void CalculateRebate(ServiceProvider serviceProvider)
    {
        var request = new CalculateRebateRequest()
        {
            RebateIdentifier = String.Empty,
            ProductIdentifier = String.Empty,
            Volume = 0m
        };

        var _rebateService = serviceProvider.GetService<IRebateService>();
        Console.WriteLine("Welcome to Justus Grant's Interview app!");
        Console.WriteLine("I am about to ask for information required to calculate your rebate!.");
        Console.WriteLine("Please enter the Rebate Identifier: ");
        request.RebateIdentifier = Console.ReadLine();
        Console.WriteLine("Please enter your Product Identifier: ");
        request.ProductIdentifier = Console.ReadLine();
        Console.WriteLine("Lastly, please enter decimal value for Volume: ");
        request.Volume = Decimal.Parse(Console.ReadLine());
        Console.WriteLine("Thank you for provideng that information.");
        var result = _rebateService.Calculate(request);
        Console.WriteLine($"Success status for your rebate: {result.Success}") ;
        Console.ReadLine();
    }
}
