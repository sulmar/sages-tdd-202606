namespace CustomerRegistration.Tests;

public class CustomersControllerTests
{
    private readonly CustomersController _controller = new();
    private readonly CustomerValidator _validator = new();

    [Fact]
    public void Post_InvalidCustomer_ReturnsBadRequest()
    {
        var customer = new Customer(1, "", 25, AcceptedTerms: true, IsDomestic: true);

        ActionResult result = _controller.Post(_validator, customer);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Post_ValidCustomer_ReturnsCreated()
    {
        var customer = new Customer(1, "john@example.com", 25, AcceptedTerms: true, IsDomestic: true);

        ActionResult result = _controller.Post(_validator, customer);

        Assert.IsType<CreatedResult>(result);
    }
}
