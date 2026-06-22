using CreateOrder.Domain;

namespace CreateOrder.Application;

public interface IOrderRepository
{
    void Save(Order order);
    Order? Get(int id);
}
