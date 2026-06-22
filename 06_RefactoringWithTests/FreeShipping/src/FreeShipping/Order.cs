namespace FreeShipping;

public record Order(
    Customer Customer,
    decimal TotalAmount,
    string Country,
    bool ContainsOversizedProducts);
