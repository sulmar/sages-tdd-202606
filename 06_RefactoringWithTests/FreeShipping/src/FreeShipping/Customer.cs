namespace FreeShipping;

public record Customer(
    bool HasActiveDeliveryPackage,
    bool IsFirstOrder);
