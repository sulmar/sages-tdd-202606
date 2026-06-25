namespace CreateOrder.Tests;


internal class MockMessageClient : IMessageClient
{
    public int Count { get; private set; }
    public void Send(string message)
    {
        Count++;
    }
}

public class OrderControllerTests
{
    [Fact]
    public void Post_ValidOrder_SendsMessageOnce()
    {
        // Arrange
        var mock = new MockMessageClient();
        var controller = new OrderController(mock);
        var order = new Order() { Id = 1 };

        // Act
        controller.Post(order);

        // Assert
        Assert.Equal(1, mock.Count);
    }
}

