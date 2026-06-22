namespace ProductCatalog.Tests;

public class FakeProductRepository : IProductRepository
{
    private readonly Dictionary<int, Product> _products = [];

    public FakeProductRepository(params Product[] products)
    {
        foreach (Product product in products)
        {
            _products[product.Id] = product;
        }
    }

    public Product? Get(int id) => _products.GetValueOrDefault(id);
}
