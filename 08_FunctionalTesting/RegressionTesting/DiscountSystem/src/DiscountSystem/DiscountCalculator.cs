namespace DiscountSystem;

public class DiscountCalculator
{
    private static readonly HashSet<string> SingleUseCodes =
    [
        "SINGLEUSE50A",
        "SINGLEUSE50B"
    ];

    private readonly HashSet<string> _usedSingleUseCodes = [];

    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

        if (discountCode == "SAVE10NOW")
            return price * 0.9m;

        if (discountCode == "DISCOUNT20OFF")
            return price * 0.8m;

        if (SingleUseCodes.Contains(discountCode))
        {
            if (_usedSingleUseCodes.Contains(discountCode))
                throw new ArgumentException("Invalid discount code");

            _usedSingleUseCodes.Add(discountCode);
            return price * 0.5m;
        }

        throw new ArgumentException("Invalid discount code");
    }
}
