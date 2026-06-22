namespace ProductCatalog;

public class ProductsController
{
    private readonly IProductRepository _repository;
    private readonly Dictionary<int, Product> _cache = [];
    private int _cacheHits;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    public ProductResponse? Get(int id)
    {
        if (_cache.TryGetValue(id, out var product))
        {
            _cacheHits++;
            return new ProductResponse(product.Id, product.Name, _cacheHits);
        }

        product = _repository.Get(id);

        if (product is null)
        {
            return null;
        }

        _cache[id] = product;
        return new ProductResponse(product.Id, product.Name, _cacheHits);
    }
}
