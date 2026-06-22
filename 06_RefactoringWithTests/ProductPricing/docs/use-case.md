# Use Case: Cennik produktu

## Opis

System oblicza kwotę pozycji zamówienia na podstawie ceny jednostkowej i ilości.

W kolejnych iteracjach system będzie rozszerzany o kolejne rabaty i promocje nakładane na cenę.

## Reguły biznesowe

### Iteracja 1

Kwota pozycji wynosi cena jednostkowa × ilość.

### Iteracja 2

Klienci należą do grup rabatowych A, B lub C. Każda grupa ma inny rabat procentowy od kwoty pozycji:

| Grupa | Rabat |
|-------|-------|
| A | 5% |
| B | 10% |
| C | 15% |

Brak przypisanej grupy — brak rabatu.

## Przykłady

### Iteracja 1

| Cena jednostkowa | Ilość | Kwota |
|------------------|-------|-------|
| 10 | 3 | 30 |
| 25 | 1 | 25 |

### Iteracja 2

| Cena jednostkowa | Ilość | Grupa | Kwota |
|------------------|-------|-------|-------|
| 100 | 2 | — | 200 |
| 100 | 2 | A | 190 |
| 100 | 2 | B | 180 |
| 100 | 2 | C | 170 |

## Implementacja

```cs
public enum CustomerDiscountGroup
{
    A,
    B,
    C
}
```

```cs
public record LineItem(
    decimal UnitPrice,
    int Quantity,
    CustomerDiscountGroup? CustomerGroup = null);
```

```cs
public class ProductPricingCalculator
{
    public decimal CalculateTotal(LineItem item)
    {
        decimal total = item.UnitPrice * item.Quantity;

        if (item.CustomerGroup == CustomerDiscountGroup.A)
            return total * 0.95m;

        if (item.CustomerGroup == CustomerDiscountGroup.B)
            return total * 0.90m;

        if (item.CustomerGroup == CustomerDiscountGroup.C)
            return total * 0.85m;

        return total;
    }
}
```

## Zadanie

Masz działające testy i monolityczną metodę `CalculateTotal`.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: proste mnożenie ceny × ilość rośnie wraz z każdym nowym rabatem.

## Pytania do dyskusji

- Co dzieje się z metodą po dodaniu kolejnej promocji (np. sezonowej, lojalnościowej)?
- Czy każdy rabat powinien być osobnym warunkiem w jednej metodzie?
- Jak testować poszczególne rabaty w izolacji?
- Jak nakładać rabaty bez modyfikowania istniejącej logiki?

## Ból

- Kolejne rabaty = kolejne if-y w jednej metodzie
- Trudne łączenie wielu promocji jednocześnie
- Każda zmiana wymaga edycji centralnej metody obliczającej cenę

## Wniosek

Wraz ze wzrostem liczby rabatów i promocji rośnie złożoność metody obliczającej kwotę pozycji.

Testy pozwalają bezpiecznie wydzielić rabaty do osobnych dekoratorów nakładanych na bazową cenę we wzorcu **Decorator**.
