using Moq;

namespace CreateOrder.Tests;

// dotnet add package Moq
public class OrderControllerMoqTests
{
    private readonly Mock<IMessageClient> mock;
    private readonly OrderController controller;

    public OrderControllerMoqTests()
    {
        mock = new Mock<IMessageClient>();
        IMessageClient client = mock.Object;
        controller = new OrderController(client);

    }

    [Fact]
    public void Post_ValidOrder_SendsMessageOnce()
    {
        // Arrange               
        var order = new Order { Id = 1 };

        // Act
        controller.Post(order);

        // Assert        
        // mock.Verify(x => x.Send("Order created"), Times.Once); // restrykcyjne
        mock.Verify(x => x.Send(It.IsAny<string>()), Moq.Times.Once); // dowolny ciag tekstowy
    }

    [Fact]
    public void Post_InvalidOrder_SendsMessageNever()
    {
        // Arrange        
        var order = new Order() { Id = 0 };

        // Act
        controller.Post(order);

        // Assert        
        // mock.Verify(x => x.Send("Order created"), Times.Once); // restrykcyjne
        mock.Verify(x => x.Send(It.IsAny<string>()), Moq.Times.Never); // dowolny ciag tekstowy
    }
}

