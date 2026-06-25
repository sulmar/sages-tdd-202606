using FakeItEasy;

namespace CreateOrder.Tests;

// dotnet add package FakeItEasy
public class OrderControllerFakeItEasyTests
{
    private readonly OrderController controller;
    private readonly IMessageClient mock;

    public OrderControllerFakeItEasyTests()
    {
        mock = A.Fake<IMessageClient>();
        controller = new OrderController(mock);
    }

    [Fact]
    public void Post_ValidOrder_SendsMessageOnce()
    {
        // Arrange               
        var order = new Order { Id = 1 };

        // Act
        controller.Post(order);

        // Assert        
        // A.CallTo(() => mock.Send("Order created")) // restrykcyjne
            // .MustHaveHappenedOnceExactly();

        A.CallTo(() => mock.Send(A<string>._)) //  dowolny ciag tekstowy
           .MustHaveHappenedOnceExactly();

    }
}
