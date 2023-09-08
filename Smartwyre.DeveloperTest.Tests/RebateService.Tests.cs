using System;
using Moq;
using NUnit.Framework;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Tests;


[TestFixture]
public class RebateServiceTests
{
    private RebateService _target;
    private Mock<IProductDataStore> _productDataStore;
    private Mock<IRebateDataStore> _rebateDataStore;

    [SetUp]
    public void SetUp()
    {
        _productDataStore = new Mock<IProductDataStore>();
        _rebateDataStore = new Mock<IRebateDataStore>();
        _target = new RebateService(_productDataStore.Object, _rebateDataStore.Object);
    }

    #region FixedRateRebate Tests

    [Test]
    public void RunRebateService_Should_Calculate_Fixed_Rate_Rebate_Success()
    {
        var testRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "PROD_ID_3E783",
            RebateIdentifier = "REB_ID_34KD94",
            Volume = 3.14159m
        };

        var rebateResponse = new Rebate()
        {
            Identifier = testRequest.RebateIdentifier,
            Amount = 100,
            Incentive = IncentiveType.FixedRateRebate,
            Percentage = 17
        };

        var productResponse = new Product()
        {
            Identifier = testRequest.ProductIdentifier,
            Id = 9,
            Price = 32.50m,
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Uom = "U_O_M"
        };

        _rebateDataStore.Setup(rds => rds.GetRebate(testRequest.RebateIdentifier))
            .Returns(rebateResponse)
            .Verifiable();

        _productDataStore.Setup(PDS => PDS.GetProduct(testRequest.ProductIdentifier))
            .Returns(productResponse)
            .Verifiable();

        var result = _target.Calculate(testRequest);
        _rebateDataStore.Verify();
        _productDataStore.Verify();
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void RunRebateService_Should_Calculate_Fixed_Rate_Rebate_Failure()
    {
        var testRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "PROD_ID_3E783",
            RebateIdentifier = "REB_ID_34KD94",
            Volume = 3.14159m
        };

        var rebateResponse = new Rebate()
        {
            Identifier = testRequest.RebateIdentifier,
            Amount = 0,
            Incentive = IncentiveType.FixedRateRebate,
            Percentage = 0
        };

        var productResponse = new Product()
        {
            Identifier = testRequest.ProductIdentifier,
            Id = 9,
            Price = 32.50m,
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Uom = "U_O_M"
        };

        _rebateDataStore.Setup(rds => rds.GetRebate(testRequest.RebateIdentifier))
            .Returns(rebateResponse)
            .Verifiable();

        _productDataStore.Setup(PDS => PDS.GetProduct(testRequest.ProductIdentifier))
            .Returns(productResponse)
            .Verifiable();

        var result = _target.Calculate(testRequest);
        _rebateDataStore.Verify();
        _productDataStore.Verify();
        Assert.That(result.Success, Is.False);
    }

    #endregion


    #region FixedCashRebate Tests

    [Test]
    public void RunRebateService_Should_Calculate_Fixed_Cash_Rebate_Success()
    {
        var testRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "PROD_ID_3E783",
            RebateIdentifier = "REB_ID_34KD94",
            Volume = 3.14159m
        };

        var rebateResponse = new Rebate()
        {
            Identifier = testRequest.RebateIdentifier,
            Amount = 100,
            Incentive = IncentiveType.FixedCashAmount,
            Percentage = 17
        };

        var productResponse = new Product()
        {
            Identifier = testRequest.ProductIdentifier,
            Id = 9,
            Price = 32.50m,
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount,
            Uom = "U_O_M"
        };

        _rebateDataStore.Setup(rds => rds.GetRebate(testRequest.RebateIdentifier))
            .Returns(rebateResponse)
            .Verifiable();

        _productDataStore.Setup(PDS => PDS.GetProduct(testRequest.ProductIdentifier))
            .Returns(productResponse)
            .Verifiable();


        var result = _target.Calculate(testRequest);
        _rebateDataStore.Verify();
        _productDataStore.Verify();
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void RunRebateService_Should_Calculate_Fixed_Cash_Rebate_Failure()
    {
        var testRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "PROD_ID_3E783",
            RebateIdentifier = "REB_ID_34KD94",
            Volume = 3.14159m
        };

        var rebateResponse = new Rebate()
        {
            Identifier = testRequest.RebateIdentifier,
            Amount = 0,
            Incentive = IncentiveType.FixedCashAmount,
            Percentage = 0
        };

        var productResponse = new Product()
        {
            Identifier = testRequest.ProductIdentifier,
            Id = 9,
            Price = 32.50m,
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount,
            Uom = "U_O_M"
        };

        _rebateDataStore.Setup(rds => rds.GetRebate(testRequest.RebateIdentifier))
            .Returns(rebateResponse)
            .Verifiable();

        _productDataStore.Setup(PDS => PDS.GetProduct(testRequest.ProductIdentifier))
            .Returns(productResponse)
            .Verifiable();


        var result = _target.Calculate(testRequest);
        _rebateDataStore.Verify();
        _productDataStore.Verify();
        Assert.That(result.Success, Is.False);
    }
    #endregion

    #region AmountPerUom Tests

    [Test]
    public void RunRebateService_Should_Calculate_Amount_Per_Uom_Rebate_Success()
    {
        var testRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "PROD_ID_3E783",
            RebateIdentifier = "REB_ID_34KD94",
            Volume = 3.14159m
        };

        var rebateResponse = new Rebate()
        {
            Identifier = testRequest.RebateIdentifier,
            Amount = 100,
            Incentive = IncentiveType.AmountPerUom,
            Percentage = 17
        };

        var productResponse = new Product()
        {
            Identifier = testRequest.ProductIdentifier,
            Id = 9,
            Price = 32.50m,
            SupportedIncentives = SupportedIncentiveType.AmountPerUom,
            Uom = "U_O_M"
        };

        _rebateDataStore.Setup(rds => rds.GetRebate(testRequest.RebateIdentifier))
            .Returns(rebateResponse)
            .Verifiable();

        _productDataStore.Setup(PDS => PDS.GetProduct(testRequest.ProductIdentifier))
            .Returns(productResponse)
            .Verifiable();


        var result = _target.Calculate(testRequest);
        _rebateDataStore.Verify();
        _productDataStore.Verify();
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void RunRebateService_Should_Calculate_Amount_Per_Uom_Rebate_Failure()
    {
        var testRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "PROD_ID_3E783",
            RebateIdentifier = "REB_ID_34KD94",
            Volume = 0m
        };

        var rebateResponse = new Rebate()
        {
            Identifier = testRequest.RebateIdentifier,
            Amount = 0,
            Incentive = IncentiveType.AmountPerUom,
            Percentage = 17
        };

        var productResponse = new Product()
        {
            Identifier = testRequest.ProductIdentifier,
            Id = 9,
            Price = 32.50m,
            SupportedIncentives = SupportedIncentiveType.AmountPerUom,
            Uom = "U_O_M"
        };

        _rebateDataStore.Setup(rds => rds.GetRebate(testRequest.RebateIdentifier))
            .Returns(rebateResponse)
            .Verifiable();

        _productDataStore.Setup(PDS => PDS.GetProduct(testRequest.ProductIdentifier))
            .Returns(productResponse)
            .Verifiable();


        var result = _target.Calculate(testRequest);
        _rebateDataStore.Verify();
        _productDataStore.Verify();
        Assert.That(result.Success, Is.False);
    }
    #endregion
}
