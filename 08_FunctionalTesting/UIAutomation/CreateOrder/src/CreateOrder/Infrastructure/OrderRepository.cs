using CreateOrder.Application;
using CreateOrder.Domain;
using Microsoft.Data.Sqlite;

namespace CreateOrder.Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly SqliteConnection _connection;

    public OrderRepository(SqliteConnection connection)
    {
        _connection = connection;
    }

    public void Save(Order order)
    {
        throw new NotImplementedException();
    }

    public Order? Get(int id)
    {
        throw new NotImplementedException();
    }
}
