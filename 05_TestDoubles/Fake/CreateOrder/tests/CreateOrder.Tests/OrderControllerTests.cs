namespace CreateOrder.Tests;


public class FakeMessageClient : IMessageClient
{
    public List<string> Messages { get; set; } = [];

    public void Send(string messsage)
    {
        Messages.Add(messsage);
    }
}

public class OrderControllerTests
{
    [Fact]
    public void Post_ValidOrder_StoresMessageInMemory()
    {
        // Arrange
        FakeMessageClient fake = new FakeMessageClient();
        var controller = new OrderController(fake);
        var order = new Order();

        // Act
        controller.Post(order);

        // Assert
        Assert.Single(fake.Messages);
        Assert.Equal("Order created", fake.Messages.Single());

    }
}
