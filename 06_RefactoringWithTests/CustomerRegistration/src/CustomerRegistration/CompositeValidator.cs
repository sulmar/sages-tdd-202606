namespace CustomerRegistration;

public class CompositeValidator : ICustomerValidator
{
    private readonly IReadOnlyList<ICustomerValidator> _validators;

    public CompositeValidator(params ICustomerValidator[] validators)
    {
        _validators = validators;
    }

    public bool Validate(Customer customer)
    {
        return _validators.All(validator => validator.Validate(customer));
    }
}
