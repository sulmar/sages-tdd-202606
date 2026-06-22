# 05_TestDoubles

| Test | Test Double |
|------|-------------|
| Czy zwracany jest CreatedResult? | Dummy |
| Czy wysłano wiadomość? | Spy |
| Czy zwracana jest ustalona wartość? | Stub |
| Czy wiadomość trafia do pamięci aplikacji? | Fake |
| Czy `Send()` zostało wywołane dokładnie raz? | Mock |

## Dummy

Interesuje nas tylko wynik:

```cs
Assert.IsType<CreatedResult<Order>>(result);
```

Używamy:

```cs
new DummyMessageClient()
```

## Spy

Interesuje nas wywołanie:

```cs
Assert.True(spy.WasCalled);
```

Używamy:

```cs
new SpyMessageClient()
```

## Stub

Interesuje nas ustalona wartość:

```cs
Assert.Equal("Coffee", name);
```

Każdy Stub steruje zachowaniem zależności w inny sposób, ale żaden nie przechowuje danych (Fake), nie rejestruje wywołań (Spy) i nie weryfikuje oczekiwań (Mock).

## Fake

Posiada uproszczoną, ale działającą implementację:

```cs
public class FakeMessageClient : IMessageClient
{
    public List<string> Messages { get; } = [];
}
```

Używamy:

```cs
Assert.Single(fake.Messages);
```

## Mock

Interesuje nas kontrakt:

```cs
mock.Verify(
    x => x.Send("Order created"),
    Times.Once);
```
