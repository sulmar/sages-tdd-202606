namespace CouponExpiration.Tests;

internal class FakeClock(DateTime now) : IClock
{
    public DateTime UtcNow => now;
}

public class FakeTimeProvider(DateTime now) : TimeProvider
{
    public override DateTimeOffset GetUtcNow() => now;
}


public class CouponTests
{
    [Fact]
    public void IsExpired_WhenExpirationIsTomorrow_ReturnsFalse()
    {
        // Arrange
        // var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-26"), now: new FakeClock(DateTime.Parse("2026-06-25")));
        var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-26"), new FakeTimeProvider(DateTime.Parse("2026-06-25")));

        // Act
        var result = coupon.IsExpired();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsExpired_WhenExpirationIsYesterday_ReturnsTrue()
    {
        // Arrange
        // var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-24"), now: new FakeClock(DateTime.Parse("2026-06-25")));
        var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-24"), new FakeTimeProvider(DateTime.Parse("2026-06-25")));

        // Act
        var result = coupon.IsExpired();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsExpired_WhenExpirationIsToday_ReturnsFalse()
    {
        // Arrange
     //   var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-25"), now: new FakeClock(DateTime.Parse("2026-06-25")));
        var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-25"), new FakeTimeProvider(DateTime.Parse("2026-06-25")));

        // Act
        var result = coupon.IsExpired();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsExpired_AtExactExpirationFuture_ReturnsFalse()
    {
        // Arrange
        // var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-30"), now: new FakeClock(DateTime.Parse("2026-06-25")));
        var coupon = new Coupon(expirationDate: DateTime.Parse("2026-06-30"), new FakeTimeProvider(DateTime.Parse("2026-06-25")));

        // Act
        var result = coupon.IsExpired();

        // Assert
        Assert.False(result);
    }
}
