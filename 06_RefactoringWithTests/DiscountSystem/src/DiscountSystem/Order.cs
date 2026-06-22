namespace DiscountSystem;

public record Order(
    DiscountType DiscountType,
    decimal TotalAmount,
    decimal PercentageRate,
    decimal FixedDiscountAmount,
    DateTime OrderTime);
