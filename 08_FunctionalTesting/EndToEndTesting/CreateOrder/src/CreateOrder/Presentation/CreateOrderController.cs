using CreateOrder.Application;

namespace CreateOrder.Presentation;

public class CreateOrderController
{
    private readonly CreateOrderUseCase _useCase;

    public CreateOrderController(CreateOrderUseCase useCase)
    {
        _useCase = useCase;
    }

    public int Create(int productId, int quantity)
    {
        return _useCase.Execute(productId, quantity);
    }
}
