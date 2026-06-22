# Use Case: Tworzenie zamówienia

## Pytanie

Czy cały proces biznesowy działa?

## Opis

Klient składa zamówienie na produkt ze sklepu internetowego.

## Clean Architecture

```
Presentation
        ↓
CreateOrderUseCase
        ↓
IProductRepository
IOrderRepository
        ↓
Sqlite
```

## Scenariusz

```
Pobierz produkt z bazy
        ↓
Utwórz zamówienie
        ↓
Zapisz zamówienie
        ↓
Zwróć numer zamówienia
```

## Oczekiwany wynik

| Element | Wartość |
|---------|---------|
| Produkt | Coffee, 100 zł |
| Ilość | 2 |
| Numer zamówienia | wygenerowany identyfikator |
| Ilość w zamówieniu | 2 |

## Test E2E

Uruchamiamy prawdziwe komponenty:

```cs
[Fact]
public void Customer_Can_Create_Order()
{
    // Arrange

    using var db =
        new SqliteConnection(
            "Data Source=:memory:");

    var products =
        new ProductRepository(db);

    var orders =
        new OrderRepository(db);

    products.Save(
        new Product(
            1,
            "Coffee",
            100));

    var useCase =
        new CreateOrderUseCase(
            products,
            orders);

    // Act

    var orderId =
        useCase.Execute(
            productId: 1,
            quantity: 2);

    // Assert

    var order =
        orders.Get(orderId);

    Assert.NotNull(order);

    Assert.Equal(
        2,
        order.Quantity);
}
```

## Cel

Test end-to-end weryfikuje współpracę prawdziwych komponentów — use case i repozytoriów SQLite — bez mocków i stubów.

## Pytania do dyskusji

- Czym test E2E różni się od testu integracyjnego?
- Dlaczego w teście E2E używamy prawdziwej bazy SQLite zamiast mocka?
- Co testujemy, a czego nie testujemy w tym scenariuszu?
- Gdzie w architekturze powinien leżeć test E2E?
