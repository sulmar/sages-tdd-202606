# Use Case: Kalkulator rabatów

## Opis

System oblicza rabat dla zamówienia.

W kolejnych iteracjach system będzie rozszerzany o nowe typy rabatów.

## Reguły biznesowe

### Iteracja 1

Rabat procentowy — rabat wynosi podaną część wartości zamówienia.

### Iteracja 2

Rabat kwotowy — rabat wynosi podaną kwotę, nie więcej niż wartość zamówienia.

### Iteracja 3

Rabat Happy Hours — w godzinach 14:00–16:00 rabat wynosi 15% wartości zamówienia.

### Iteracja 4

Rabat weekendowy — w sobotę lub niedzielę rabat wynosi 10% wartości zamówienia.

## Przykłady

### Iteracja 1

| Typ rabatu | Kwota zamówienia | Stawka procentowa | Rabat |
|------------|------------------|-------------------|-------|
| Procentowy | 200 | 10% | 20 |
| Procentowy | 150 | 0% | 0 |

### Iteracja 2

| Typ rabatu | Kwota zamówienia | Kwota rabatu | Rabat |
|------------|------------------|--------------|-------|
| Kwotowy | 200 | 50 | 50 |
| Kwotowy | 30 | 50 | 30 |

### Iteracja 3

| Typ rabatu | Kwota zamówienia | Godzina zamówienia | Rabat |
|------------|------------------|--------------------|-------|
| Happy Hours | 200 | 15:00 | 30 |
| Happy Hours | 200 | 12:00 | 0 |

### Iteracja 4

| Typ rabatu | Kwota zamówienia | Dzień zamówienia | Rabat |
|------------|------------------|------------------|-------|
| Weekendowy | 200 | Sobota | 20 |
| Weekendowy | 200 | Poniedziałek | 0 |

## Implementacja

```cs
public enum DiscountType
{
    Percentage,
    FixedAmount,
    HappyHours,
    Weekend
}
```

```cs
public record Order(
    DiscountType DiscountType,
    decimal TotalAmount,
    decimal PercentageRate,
    decimal FixedDiscountAmount,
    DateTime OrderTime);
```

```cs
public class DiscountCalculator
{
    public decimal CalculateDiscount(Order order)
    {
        if (order.DiscountType == DiscountType.Percentage)
            return order.TotalAmount * order.PercentageRate;

        if (order.DiscountType == DiscountType.FixedAmount)
            return Math.Min(order.FixedDiscountAmount, order.TotalAmount);

        if (order.DiscountType == DiscountType.HappyHours)
        {
            TimeSpan time = order.OrderTime.TimeOfDay;

            if (time >= TimeSpan.FromHours(14) && time < TimeSpan.FromHours(16))
                return order.TotalAmount * 0.15m;

            return 0;
        }

        if (order.DiscountType == DiscountType.Weekend)
        {
            if (order.OrderTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                return order.TotalAmount * 0.10m;

            return 0;
        }

        return 0;
    }
}
```

## Zadanie

Masz działające testy i monolityczną metodę `CalculateDiscount`.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: kolejne typy rabatów, rosnąca liczba warunków, jedna metoda z wieloma algorytmami.

## Pytania do dyskusji

- Co dzieje się z metodą po dodaniu kolejnego typu rabatu?
- Czy wszystkie algorytmy rabatowe powinny żyć w jednej klasie?
- Jak testować poszczególne reguły rabatowe w izolacji?
- Jak wydzielić algorytmy do osobnych strategii?

## Ból

- Kolejne typy rabatów = kolejne if-y
- Rosnąca złożoność jednej metody
- Trudne rozszerzanie o nowe algorytmy rabatowe

## Wniosek

Wraz ze wzrostem liczby typów rabatów rośnie złożoność metody obliczającej rabat.

Testy pozwalają bezpiecznie wydzielić algorytmy do osobnych klas i wybrać właściwą strategię we wzorcu **Strategy**.
