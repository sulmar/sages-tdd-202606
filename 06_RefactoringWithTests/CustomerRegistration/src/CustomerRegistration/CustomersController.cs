namespace CustomerRegistration;

public class CustomersController
{
    public ActionResult Post(CustomerValidator validator, Customer customer)
    {
        bool isValid = validator.Validate(customer);

        if (!isValid)
        {
            return new BadRequestObjectResult("Invalid customer data");
        }

        return new CreatedResult($"/customers/{customer.Id}", customer);
    }
}

public interface ActionResult { }

public class CreatedResult : ActionResult
{
    public CreatedResult(string? location, object? value) { }
}

public class BadRequestObjectResult : ActionResult
{
    public BadRequestObjectResult(object? error) { }
}
