namespace CustomerRegistration;

public class CustomerValidator
{
    public bool Validate(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Email))
            return false;

        if (customer.Age < 18)
            return false;

        if (!customer.AcceptedTerms)
            return false;

        if (!customer.IsDomestic)
            return false;

        return true;
    }
}
