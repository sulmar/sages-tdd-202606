namespace CustomerRegistration;

public class AdultAgeValidator : ICustomerValidator
{
    public bool Validate(Customer customer)
    {
        return customer.Age >= 18;
    }
}
