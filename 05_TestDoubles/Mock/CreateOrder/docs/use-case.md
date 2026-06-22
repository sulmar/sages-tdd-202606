# Use Case: Tworzenie zamówienia

## Opis

System umożliwia utworzenie zamówienia.

Po utworzeniu zamówienia system wysyła wiadomość informującą o jego utworzeniu.

W tym ćwiczeniu chcemy przetestować, czy metoda `Send()` została wywołana dokładnie raz z właściwą treścią.

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
- Test kontraktu wywołania nie powinien zależeć od prawdziwej usługi zewnętrznej.

## Zadanie

Zrefaktoryzuj kod tak, aby zależność od wysyłania wiadomości można było zastąpić w teście.

Następnie zaimplementuj test:

```cs
[Fact]
public void Post_ValidOrder_SendsMessageOnce()
{
    throw new NotImplementedException();
}
```

Użyj mocka do weryfikacji kontraktu:

```cs
mock.Verify(
    x => x.Send("Order created"),
    Times.Once);
```

## Pytania do dyskusji

- Czym mock różni się od spya?
- Czy mock weryfikuje stan czy kontrakt wywołania?
- Kiedy mock staje się kruchy?

## Wniosek

Mock to obiekt, który weryfikuje oczekiwania co do sposobu wywołania.

Test definiuje kontrakt przed wykonaniem kodu i weryfikuje go po jego wykonaniu.
