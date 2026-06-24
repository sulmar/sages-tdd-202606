namespace DiscountSystem.Tests;

public class DiscountCalculatorTests
{
    readonly DiscountCalculator discountCalculator;
    readonly ICouponCodeRepository couponCodeRepository;   

    public DiscountCalculatorTests()
    {
        couponCodeRepository = new SingleUseCouponCodeRepository(
                                    new UseCouponCodeRepository());

        discountCalculator = new DiscountCalculator(couponCodeRepository);
    }


    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    public void CalculateDiscount_EmptyCouponCode_ReturnsZero(string couponCode)
    {     
        // Act
        var result = discountCalculator.CalculateDiscount(100, couponCode);

        // Assert
        Assert.Equal(0, result);
    }

    #region

    [Fact]
    public void CalculateDiscount_CouponCodeSAVE10NOW_ReturnsDiscount()
    {
        // Act
        couponCodeRepository.Add(new ("SAVE10NOW", 0.1m, false));
        var result = discountCalculator.CalculateDiscount(100, "SAVE10NOW");

        // Assert
        Assert.Equal(10, result);
    }

   

    [Fact]
    public void CalculateDiscount_CouponCodeDISCOUNT20OFF_ReturnsDiscount()
    {
        // Act
        couponCodeRepository.Add(new ("DISCOUNT20OFF", 0.2m));
        var result = discountCalculator.CalculateDiscount(100, "DISCOUNT20OFF");

        // Assert
        Assert.Equal(20, result);
    }

    #endregion

    [Theory]    
    [InlineData("SAVE10NOW", 0.1, 10)]
    [InlineData("DISCOUNT20OFF", 0.2, 20)]
    public void CalculateDiscount_ValidCouponCode_ReturnsDiscount(string couponCode, decimal discount, decimal expectedDiscount)
    {
        // Act
        couponCodeRepository.Add(new (couponCode, discount));
        var result = discountCalculator.CalculateDiscount(100, couponCode);
        // Assert
        Assert.Equal(expectedDiscount, result);
    }

    [Fact]
    public void CalculateDiscount_NegativePrice_ThrowsArgumentException()
    {       
        // Act & Assert
        Assert.Throws<ArgumentException>(() => discountCalculator.CalculateDiscount(-100, "a"));
    }


    [Fact]
    public void CalculateDiscount_InvalidCouponCode_ThrowsArgumentExceptionWithMessage()
    {        
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => discountCalculator.CalculateDiscount(100, "INVALIDCODE"));

        Assert.Equal("Invalid discount code.", exception.Message);
    }

    // Rabat jednorazowy 50% - Kupon z kodem, który jest częścią predefiniowanej puli kodów rabatowych, udziela jednorazowego rabatu 50%.
    [Fact]
    public void CalculateDiscount_SecondUsageOneTimeCouponCode_ThrowsArgumentExceptionWithMessage()
    {
        // Arrange   
        couponCodeRepository.Add(new ("ONETIME50", 0.5m, true));

        discountCalculator.CalculateDiscount(100, "ONETIME50"); // First usage

       // Act & Assert
       var exception = Assert.Throws<ArgumentException>(() => discountCalculator.CalculateDiscount(100, "ONETIME50")); // Second usage
    }
}
