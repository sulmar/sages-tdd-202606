namespace CustomerRegistration;

public class EmailValidator : ICustomerValidator
{
    public bool Validate(Customer customer)
    {
        return !string.IsNullOrWhiteSpace(customer.Email);
    }
}
