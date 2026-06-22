using CreateOrder.Application;
using CreateOrder.Domain;
using Microsoft.Data.Sqlite;

namespace CreateOrder.Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly SqliteConnection _connection;

    public ProductRepository(SqliteConnection connection)
    {
        _connection = connection;
    }

    public Product Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Save(Product product)
    {
        throw new NotImplementedException();
    }
}
