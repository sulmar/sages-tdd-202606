namespace CustomerRegistration.Tests;

public class CustomerValidatorTests
{
    private readonly CustomerValidator _validator = new();

    [Fact]
    public void Validate_CustomerWithoutEmail_ReturnsFalse()
    {
        var customer = new Customer(1, "", 25, AcceptedTerms: true, IsDomestic: true);

        bool result = _validator.Validate(customer);

        Assert.False(result);
    }

    [Fact]
    public void Validate_UnderageCustomer_ReturnsFalse()
    {
        var customer = new Customer(1, "john@example.com", 17, AcceptedTerms: true, IsDomestic: true);

        bool result = _validator.Validate(customer);

        Assert.False(result);
    }

    [Fact]
    public void Validate_CustomerWithoutAcceptedTerms_ReturnsFalse()
    {
        var customer = new Customer(1, "john@example.com", 25, AcceptedTerms: false, IsDomestic: true);

        bool result = _validator.Validate(customer);

        Assert.False(result);
    }

    [Fact]
    public void Validate_ForeignCustomer_ReturnsFalse()
    {
        var customer = new Customer(1, "john@example.com", 25, AcceptedTerms: true, IsDomestic: false);

        bool result = _validator.Validate(customer);

        Assert.False(result);
    }

    [Fact]
    public void Validate_ValidCustomer_ReturnsTrue()
    {
        var customer = new Customer(1, "john@example.com", 25, AcceptedTerms: true, IsDomestic: true);

        bool result = _validator.Validate(customer);

        Assert.True(result);
    }
}
