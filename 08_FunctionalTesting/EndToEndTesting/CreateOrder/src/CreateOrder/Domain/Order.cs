namespace CreateOrder.Domain;

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public Order(int productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}
