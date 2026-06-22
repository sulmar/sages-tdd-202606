# Use Case: Tworzenie zamówienia

## Opis

System umożliwia utworzenie zamówienia.

Po utworzeniu zamówienia system wysyła wiadomość informującą o jego utworzeniu.

W tym ćwiczeniu chcemy przetestować, czy po utworzeniu zamówienia wiadomość została wysłana.

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
public void Post_ValidOrder_SendsMessage()
{
    throw new NotImplementedException();
}
```

Użyj spya, który rejestruje wywołanie:

```cs
Assert.True(spy.WasCalled);
```

## Pytania do dyskusji

- Czy ten test sprawdza wynik metody `Post()`?
- Czym spy różni się od dummy?
- Czy spy weryfikuje argumenty wywołania?

## Wniosek

Spy to obiekt, który rejestruje sposób, w jaki został użyty.

Test sprawdza stan spya po wykonaniu testowanego kodu.
