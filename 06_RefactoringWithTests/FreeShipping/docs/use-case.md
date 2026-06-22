# Use Case: Darmowa dostawa

## Opis

System decyduje, czy zamówienie kwalifikuje się do darmowej dostawy.

Reguły łączą warunki logiczne (AND, OR) oraz wyjątki biznesowe.

## Reguły biznesowe

Zamówienie kwalifikuje się do darmowej dostawy, gdy:

1. Klient ma aktywny pakiet dostaw — **zawsze** kwalifikuje się (wyjątek biznesowy).
2. Lub jednocześnie:
   - wartość zamówienia wynosi co najmniej 500 **albo** to pierwsze zamówienie klienta,
   - kraj dostawy to Polska (`PL`),
   - zamówienie nie zawiera produktów ponadgabarytowych.

## Przykłady

| Pakiet dostaw | Pierwsze zamówienie | Kwota | Kraj | Produkty ponadgabarytowe | Wynik |
|---------------|---------------------|-------|------|--------------------------|-------|
| Tak | Nie | 100 | DE | Tak | Kwalifikuje się |
| Nie | Nie | 500 | PL | Nie | Kwalifikuje się |
| Nie | Tak | 100 | PL | Nie | Kwalifikuje się |
| Nie | Nie | 499 | PL | Nie | Nie kwalifikuje się |
| Nie | Tak | 500 | DE | Nie | Nie kwalifikuje się |
| Nie | Tak | 500 | PL | Tak | Nie kwalifikuje się |

## Implementacja

```cs
public record Customer(
    bool HasActiveDeliveryPackage,
    bool IsFirstOrder);

public record Order(
    Customer Customer,
    decimal TotalAmount,
    string Country,
    bool ContainsOversizedProducts);
```

```cs
public class FreeShipping
{
    public bool Qualifies(Order order)
    {
        if (order.Customer.HasActiveDeliveryPackage)
            return true;

        if ((order.TotalAmount >= 500 || order.Customer.IsFirstOrder)
            && order.Country == "PL"
            && !order.ContainsOversizedProducts)
        {
            return true;
        }

        return false;
    }
}
```

## Zadanie

Masz działające testy i monolityczną metodę `Qualifies`.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: AND + OR + wyjątki biznesowe w jednej metodzie.

## Pytania do dyskusji

- Czy warunki w metodzie są łatwe do odczytania?
- Jak testować kolejne wyjątki biznesowe?
- Jak rozdzielić reguły na mniejsze, niezależne specyfikacje?
- Jak łączyć specyfikacje (AND, OR)?

## Ból

- AND + OR + wyjątki biznesowe
- Rosnąca złożoność warunków
- Trudne rozszerzanie o nowe kryteria

## Wniosek

Wraz ze wzrostem liczby kryteriów rośnie złożoność warunków w jednej metodzie.

Testy pozwalają bezpiecznie wydzielić reguły do osobnych specyfikacji i połączyć je we wzorcu **Specification**.
