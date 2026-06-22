namespace ProductCatalog;

public record Product(int Id, string Name);

public class ProductRepository
{
    public Product? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Save(Product product)
    {
        throw new NotImplementedException();
    }
}
