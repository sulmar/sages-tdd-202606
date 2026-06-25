namespace CreateOrder.Tests;

internal class SpyMessageClient : IMessageClient
{
    public bool WasCalled { get; private set; }

    public void Send(string message) => WasCalled = true;
}

public class OrderControllerTests
{
    [Fact]
    public void Post_ValidOrder_SendsMessage()
    {
        // Arrange
        var spy = new SpyMessageClient();
        var controller = new OrderController(spy);
        var order = new Order();

        // Act
        controller.Post(order);

        // Assert
        Assert.True(spy.WasCalled);

    }
}
