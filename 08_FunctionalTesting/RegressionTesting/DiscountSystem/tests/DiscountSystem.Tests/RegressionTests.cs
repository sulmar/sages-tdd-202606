namespace DiscountSystem.Tests;

public class RegressionTests
{
    private readonly global::DiscountSystem.DiscountCalculator _calculator = new();

    [Theory]
    [InlineData(100, "SAVE10NOW", 90)]
    [InlineData(100, "DISCOUNT20OFF", 80)]
    [InlineData(100, "", 100)]
    public void ExistingCoupons_ShouldStillWork(
        decimal price,
        string coupon,
        decimal expected)
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void SingleUseCoupon_ShouldStillWork()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void InvalidCoupon_ShouldStillThrow()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void NegativePrice_ShouldStillThrow()
    {
        throw new NotImplementedException();
    }
}
