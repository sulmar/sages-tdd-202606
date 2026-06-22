namespace ProductPricing;

public record LineItem(
    decimal UnitPrice,
    int Quantity,
    CustomerDiscountGroup? CustomerGroup = null);
