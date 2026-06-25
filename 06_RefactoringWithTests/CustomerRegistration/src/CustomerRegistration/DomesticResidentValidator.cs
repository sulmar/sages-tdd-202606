namespace CustomerRegistration;

public class DomesticResidentValidator : ICustomerValidator
{
    public bool Validate(Customer customer)
    {
        return customer.IsDomestic;
    }
}
