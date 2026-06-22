using CreateOrder.Domain;

namespace CreateOrder.Application;

public class CreateOrderUseCase
{
    private readonly IProductRepository _products;
    private readonly IOrderRepository _orders;

    public CreateOrderUseCase(
        IProductRepository products,
        IOrderRepository orders)
    {
        _products = products;
        _orders = orders;
    }

    public int Execute(
        int productId,
        int quantity)
    {
        var product =
            _products.Get(productId);

        var order =
            new Order(
                productId,
                quantity,
                product.Price);

        _orders.Save(order);

        return order.Id;
    }
}
