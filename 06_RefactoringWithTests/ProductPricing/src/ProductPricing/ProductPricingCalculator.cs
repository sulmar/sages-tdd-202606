namespace ProductPricing;

public class ProductPricingCalculator
{
    public decimal CalculateTotal(LineItem item)
    {
        decimal total = item.UnitPrice * item.Quantity;

        if (item.CustomerGroup == CustomerDiscountGroup.A)
            return total * 0.95m;

        if (item.CustomerGroup == CustomerDiscountGroup.B)
            return total * 0.90m;

        if (item.CustomerGroup == CustomerDiscountGroup.C)
            return total * 0.85m;

        return total;
    }
}
