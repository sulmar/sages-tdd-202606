namespace CustomerRegistration.Tests;

public class CompositeValidatorTests
{
    [Fact]
    public void Validate_AllValidatorsPass_ReturnsTrue()
    {
        var validator = new CompositeValidator(
            new EmailValidator(),
            new AdultAgeValidator(),
            new AcceptedTermsValidator(),
            new DomesticResidentValidator());
        var customer = new Customer(1, "john@example.com", 25, AcceptedTerms: true, IsDomestic: true);

        bool result = validator.Validate(customer);

        Assert.True(result);
    }

    [Fact]
    public void Validate_OneValidatorFails_ReturnsFalse()
    {
        var validator = new CompositeValidator(
            new EmailValidator(),
            new AdultAgeValidator());
        var customer = new Customer(1, "john@example.com", 17, AcceptedTerms: true, IsDomestic: true);

        bool result = validator.Validate(customer);

        Assert.False(result);
    }
}
