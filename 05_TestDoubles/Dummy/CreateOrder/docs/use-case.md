# Use Case: Tworzenie zamówienia

## Opis

System umożliwia utworzenie zamówienia.

Po utworzeniu zamówienia system wysyła wiadomość informującą o jego utworzeniu.

W tym ćwiczeniu chcemy przetestować, czy metoda zwraca poprawny wynik po utworzeniu zamówienia.

Nie chcemy testować wysyłania wiadomości ani łączyć się z prawdziwą usługą zewnętrzną.

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
- Test zwracania `CreatedResult` nie powinien zależeć od prawdziwej usługi wysyłania wiadomości.

## Zadanie

Zrefaktoryzuj kod tak, aby zależność od wysyłania wiadomości można było zastąpić w teście.

Następnie zaimplementuj test:

```cs
[Fact]
public void Post_ValidOrder_ReturnsCreatedResult()
{
    throw new NotImplementedException();
}
```

## Pytania do dyskusji

- Czy ten test sprawdza wysyłanie wiadomości?
- Czy do tego testu potrzebny jest prawdziwy `GmailApiClient`?

## Wniosek

Dummy to obiekt przekazany do testowanego kodu tylko dlatego, że jest wymagany przez konstruktor lub metodę.

Test nie korzysta z jego zachowania i nie sprawdza jego stanu.
