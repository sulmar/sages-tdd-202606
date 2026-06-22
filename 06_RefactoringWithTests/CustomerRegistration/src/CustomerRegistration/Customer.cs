namespace CustomerRegistration;

public record Customer(
    int Id,
    string Email,
    int Age,
    bool AcceptedTerms,
    bool IsDomestic);
