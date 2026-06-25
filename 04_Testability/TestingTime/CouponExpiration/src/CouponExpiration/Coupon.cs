namespace CouponExpiration;

public interface IClock
{
    DateTime UtcNow { get; }
}

public sealed class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}

public class Coupon
{
    private readonly IClock clock;
    public DateTime ExpirationDate { get; }

    private readonly TimeProvider timeProvider;

    //public Coupon(DateTime expirationDate)
    //    : this(expirationDate, new SystemClock())
    //{

    //}

    public Coupon(DateTime expirationDate)
        : this(expirationDate, TimeProvider.System)
    {        
    }

    public Coupon(DateTime expirationDate, TimeProvider timeProvider)
    {
        this.ExpirationDate = expirationDate;
        this.timeProvider = timeProvider;
    }

    public Coupon(DateTime expirationDate, IClock now)
    {
        ExpirationDate = expirationDate;
        this.clock = now;
    }

    public bool IsExpired()
    {
        //return clock.UtcNow > ExpirationDate;
        return timeProvider.GetUtcNow().UtcDateTime > ExpirationDate;
    }
}
