using CreateOrder.Domain;

namespace CreateOrder.Application;

public interface IProductRepository
{
    Product Get(int id);
    void Save(Product product);
}
