namespace DiscountSystem;

public class DiscountCalculator
{
    // Predefiniowana puli kodów rabatowych
    private readonly Dictionary<string, decimal> oneTimeCouponCodes = [];

    public DiscountCalculator()
    {
        oneTimeCouponCodes.Add("ONETIME50", 0.5m);
        oneTimeCouponCodes.Add("HAPPY50", 0.5m);
    }

    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrWhiteSpace(discountCode))
        {
            return 0;
        }

        if (discountCode == "SAVE10NOW")
        {
            return price * 0.10m;
        }

        if (discountCode == "DISCOUNT20OFF")
        {
            return price * 0.20m;
        }

        if (oneTimeCouponCodes.TryGetValue(discountCode, out var discount))
        {
            oneTimeCouponCodes.Remove(discountCode);
            return price * discount;
        }

        throw new ArgumentException("Invalid discount code.");

    }
}
