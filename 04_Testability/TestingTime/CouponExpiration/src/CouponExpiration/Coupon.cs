namespace CouponExpiration;

public class Coupon
{
    public DateTime ExpirationDate { get; }

    public Coupon(DateTime expirationDate)
    {
        ExpirationDate = expirationDate;
    }

    public bool IsExpired()
    {
        return DateTime.UtcNow > ExpirationDate;
    }
}
