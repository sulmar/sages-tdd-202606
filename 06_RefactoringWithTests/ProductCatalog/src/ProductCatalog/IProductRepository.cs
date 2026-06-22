namespace ProductCatalog;

public interface IProductRepository
{
    Product? Get(int id);
}
