namespace ArrangeActAssert;

public class ShoppingCart
{
    private readonly List<CartItem> _items = [];

    public DateTime CreatedAt { get; }

    public ShoppingCart()
    {
        CreatedAt = DateTime.UtcNow;        
    }

    public void AddProduct(string name, decimal price)
    {
        _items.Add(new CartItem(name, price));
    }
    
    public void RemoveProduct(string name)
    {
        var item = _items.FirstOrDefault(x => x.Name == name);

        if (item is not null)
        {
            _items.Remove(item);
        }
    }

    public decimal CalculateTotal()
    {
        return _items.Sum(x => x.Price);
    }
}

public record CartItem(string Name, decimal Price);