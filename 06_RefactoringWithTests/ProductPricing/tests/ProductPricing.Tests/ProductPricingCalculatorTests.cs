namespace ProductPricing.Tests;

public class ProductPricingCalculatorTests
{
    private readonly ProductPricingCalculator _calculator = new();

    [Fact]
    public void CalculateTotal_UnitPriceTimesQuantity_ReturnsTotal()
    {
        var item = new LineItem(UnitPrice: 10, Quantity: 3);

        decimal result = _calculator.CalculateTotal(item);

        Assert.Equal(30, result);
    }

    [Fact]
    public void CalculateTotal_SingleItem_ReturnsUnitPrice()
    {
        var item = new LineItem(UnitPrice: 25, Quantity: 1);

        decimal result = _calculator.CalculateTotal(item);

        Assert.Equal(25, result);
    }

    [Fact]
    public void CalculateTotal_CustomerGroupA_AppliesFivePercentDiscount()
    {
        var item = new LineItem(UnitPrice: 100, Quantity: 2, CustomerGroup: CustomerDiscountGroup.A);

        decimal result = _calculator.CalculateTotal(item);

        Assert.Equal(190, result);
    }

    [Fact]
    public void CalculateTotal_CustomerGroupB_AppliesTenPercentDiscount()
    {
        var item = new LineItem(UnitPrice: 100, Quantity: 2, CustomerGroup: CustomerDiscountGroup.B);

        decimal result = _calculator.CalculateTotal(item);

        Assert.Equal(180, result);
    }

    [Fact]
    public void CalculateTotal_CustomerGroupC_AppliesFifteenPercentDiscount()
    {
        var item = new LineItem(UnitPrice: 100, Quantity: 2, CustomerGroup: CustomerDiscountGroup.C);

        decimal result = _calculator.CalculateTotal(item);

        Assert.Equal(170, result);
    }
}
