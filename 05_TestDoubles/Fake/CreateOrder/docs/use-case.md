# Use Case: Tworzenie zamówienia

## Opis

System umożliwia utworzenie zamówienia.

Po utworzeniu zamówienia system wysyła wiadomość informującą o jego utworzeniu.

W tym ćwiczeniu chcemy przetestować, czy wiadomość trafia do pamięci aplikacji.

Nie chcemy łączyć się z prawdziwą usługą zewnętrzną.

## Problem

Początkowa implementacja tworzy klienta wiadomości bezpośrednio w metodzie:

```cs
public ActionResult Post(Order order)
{
    var gmailClient = new GmailApiClient();
    gmailClient.Send("Order created");
    return new CreatedResult<Order>(order);
}
```

Taki kod utrudnia testowanie, ponieważ test metody `Post()` może uruchomić prawdziwą komunikację z zewnętrzną usługą.

## Reguły biznesowe

- Poprawne zamówienie powinno zostać utworzone.
- Po utworzeniu zamówienia system powinien wysłać wiadomość.
- Test wysyłania wiadomości nie powinien zależeć od prawdziwej usługi zewnętrznej.

## Zadanie

Zrefaktoryzuj kod tak, aby zależność od wysyłania wiadomości można było zastąpić w teście.

Następnie zaimplementuj test:

```cs
[Fact]
public void Post_ValidOrder_StoresMessageInMemory()
{
    throw new NotImplementedException();
}
```

Użyj fake'a z uproszczoną, ale działającą implementacją:

```cs
public class FakeMessageClient : IMessageClient
{
    public List<string> Messages { get; } = [];
}

Assert.Single(fake.Messages);
```

## Pytania do dyskusji

- Czy fake wysyła wiadomość poza aplikacją?
- Czym fake różni się od spya?
- Kiedy fake jest lepszym wyborem niż mock?

## Wniosek

Fake to obiekt z uproszczoną, ale działającą implementacją.

Test korzysta ze stanu fake'a, aby sprawdzić efekt działania testowanego kodu.
