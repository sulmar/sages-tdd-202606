namespace CreateOrder.Tests;

public class OrderControllerTests
{
    [Fact]
    public void Post_ValidOrder_ReturnsCreatedResult()
    {
        // Arrange
        var controller = new OrderController(new DummyMessageClient());
        var order = new Order();

        // Act
        ActionResult result = controller.Post(order);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CreatedResult<Order>>(result);
    }


    // Dummy - obiekt zastepczy, zaslepka, nic nie robi
    class DummyMessageClient : IMessageClient
    {
        public void Send(string message)
        {
            // nic nie rób
        }
    }
}
