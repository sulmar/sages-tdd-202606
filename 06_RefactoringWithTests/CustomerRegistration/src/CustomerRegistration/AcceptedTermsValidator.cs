namespace CustomerRegistration;

public class AcceptedTermsValidator : ICustomerValidator
{
    public bool Validate(Customer customer)
    {
        return customer.AcceptedTerms;
    }
}
