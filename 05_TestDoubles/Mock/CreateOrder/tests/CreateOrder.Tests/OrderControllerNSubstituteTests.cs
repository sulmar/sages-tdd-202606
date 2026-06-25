using NSubstitute;

namespace CreateOrder.Tests;

// dotnet add package NSubstitute
public class OrderControllerNSubstituteTests
{
    private readonly OrderController controller;
    private readonly IMessageClient mock;

    public OrderControllerNSubstituteTests()
    {
        mock = Substitute.For<IMessageClient>();
        controller = new OrderController(mock);
    }

    [Fact]
    public void Post_ValidOrder_SendsMessageOnce()
    {
        // Arrange               
        var order = new Order { Id = 1 };
        mock.Send("Order created");

        // Act
        controller.Post(order);

        // Assert        
        mock.Received().Send("Order created");
        // mock.Received().Send(Arg.Any<string>());    

    }
}
