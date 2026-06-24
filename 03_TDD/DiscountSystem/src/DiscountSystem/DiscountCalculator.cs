using System.Net.Http.Headers;

namespace DiscountSystem;

public record Coupon(string Code, decimal Discount, bool SingleUse = false);

public interface ICouponCodeRepository
{
    void Add(Coupon coupon);
    Coupon? Get(string couponCode);
  
}

public class SingleUseCouponCodeRepository : ICouponCodeRepository
{
    // Predefiniowana puli kodów rabatowych
    private readonly HashSet<string> usedCodes = [];

    private readonly ICouponCodeRepository _inner;

    public SingleUseCouponCodeRepository(ICouponCodeRepository inner)
    {
        this._inner = inner;
    }

    public void Add(Coupon coupon)
    {
        _inner.Add(coupon);
    }

    public Coupon? Get(string couponCode)
    {
        var coupon = _inner.Get(couponCode);

        if (coupon == null)
            return null;

        if (coupon.SingleUse)
        {
            if (usedCodes.Contains(couponCode))
                return null;

            usedCodes.Add(couponCode);
        }
            
        return coupon;
    }

  
}

public class UseCouponCodeRepository : ICouponCodeRepository
{
    // Predefiniowana puli kodów rabatowych
    private readonly Dictionary<string, Coupon> couponCodes = [];

    public void Add(Coupon coupon)
    {
        couponCodes.Add(coupon.Code, coupon);
    }

    public Coupon? Get(string couponCode)
    {
        if (couponCodes.TryGetValue(couponCode, out var discount))
        {
            return discount;
        }

        return null;
    }
    
}

public class DiscountCalculator(ICouponCodeRepository repository)
{     
    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrWhiteSpace(discountCode))
        {
            return 0;
        }
        
        var coupon = repository.Get(discountCode) ?? throw new ArgumentException("Invalid discount code.");

        return price * coupon.Discount;
    }
}
