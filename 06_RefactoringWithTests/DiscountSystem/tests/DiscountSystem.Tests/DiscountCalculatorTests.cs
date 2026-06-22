namespace DiscountSystem.Tests;

public class DiscountCalculatorTests
{
    private readonly global::DiscountSystem.DiscountCalculator _calculator = new();
    private static readonly DateTime DefaultOrderTime = new(2026, 6, 22, 12, 0, 0);

    [Fact]
    public void CalculateDiscount_PercentageDiscount_ReturnsPercentageOfTotal()
    {
        var order = new Order(
            DiscountType.Percentage,
            TotalAmount: 200,
            PercentageRate: 0.10m,
            FixedDiscountAmount: 0,
            OrderTime: DefaultOrderTime);

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(20, result);
    }

    [Fact]
    public void CalculateDiscount_ZeroPercentageRate_ReturnsZero()
    {
        var order = new Order(
            DiscountType.Percentage,
            TotalAmount: 150,
            PercentageRate: 0,
            FixedDiscountAmount: 0,
            OrderTime: DefaultOrderTime);

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(0, result);
    }

    [Fact]
    public void CalculateDiscount_FixedAmountDiscount_ReturnsFixedAmount()
    {
        var order = new Order(
            DiscountType.FixedAmount,
            TotalAmount: 200,
            PercentageRate: 0,
            FixedDiscountAmount: 50,
            OrderTime: DefaultOrderTime);

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(50, result);
    }

    [Fact]
    public void CalculateDiscount_FixedAmountExceedsTotal_ReturnsTotalAmount()
    {
        var order = new Order(
            DiscountType.FixedAmount,
            TotalAmount: 30,
            PercentageRate: 0,
            FixedDiscountAmount: 50,
            OrderTime: DefaultOrderTime);

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(30, result);
    }

    [Fact]
    public void CalculateDiscount_HappyHoursDuringPromotion_ReturnsFifteenPercent()
    {
        var order = new Order(
            DiscountType.HappyHours,
            TotalAmount: 200,
            PercentageRate: 0,
            FixedDiscountAmount: 0,
            OrderTime: new DateTime(2026, 6, 22, 15, 0, 0));

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(30, result);
    }

    [Fact]
    public void CalculateDiscount_HappyHoursOutsidePromotion_ReturnsZero()
    {
        var order = new Order(
            DiscountType.HappyHours,
            TotalAmount: 200,
            PercentageRate: 0,
            FixedDiscountAmount: 0,
            OrderTime: DefaultOrderTime);

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(0, result);
    }

    [Fact]
    public void CalculateDiscount_WeekendOrder_ReturnsTenPercent()
    {
        var order = new Order(
            DiscountType.Weekend,
            TotalAmount: 200,
            PercentageRate: 0,
            FixedDiscountAmount: 0,
            OrderTime: new DateTime(2026, 6, 20, 12, 0, 0));

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(20, result);
    }

    [Fact]
    public void CalculateDiscount_WeekdayOrder_ReturnsZero()
    {
        var order = new Order(
            DiscountType.Weekend,
            TotalAmount: 200,
            PercentageRate: 0,
            FixedDiscountAmount: 0,
            OrderTime: DefaultOrderTime);

        decimal result = _calculator.CalculateDiscount(order);

        Assert.Equal(0, result);
    }
}
