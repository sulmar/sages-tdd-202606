# Use Case: Testy regresyjne — Kalkulator rabatów

## Pytanie

Czy nowa zmiana nie zepsuła istniejących funkcji?

## Opis

System kalkulatora rabatów działa w produkcji. Klienci korzystają z kuponów `SAVE10NOW`, `DISCOUNT20OFF` oraz jednorazowych kodów rabatowych.

Zespół planuje wdrożenie nowego kuponu **`HAPPYHOURS50`** — rabatu 50% w godzinach 14:00–16:00.

Przed wdrożeniem uruchamiamy pakiet testów regresyjnych, aby upewnić się, że istniejące funkcje nadal działają poprawnie.

## Pakiet regresyjny

| Test | Co weryfikuje |
|------|---------------|
| `ExistingCoupons_ShouldStillWork` | `SAVE10NOW`, `DISCOUNT20OFF`, pusty kod |
| `SingleUseCoupon_ShouldStillWork` | jednorazowy rabat 50% |
| `InvalidCoupon_ShouldStillThrow` | błędny kod kuponu |
| `NegativePrice_ShouldStillThrow` | ujemna cena |

## Reguły biznesowe (istniejące)

1. **Pusty kod kuponu** — rabat nie jest udzielany, zwracana jest cena bez zmian.
2. **Rabat 10%** — kupon `SAVE10NOW` udziela rabatu 10%.
3. **Rabat 20%** — kupon `DISCOUNT20OFF` udziela rabatu 20%.
4. **Obsługa ujemnych cen** — wywołanie z ujemną ceną rzuca `ArgumentException` z komunikatem `"Negatives not allowed"`.
5. **Błędny kod kuponu** — wywołanie z nieprawidłowym kodem rzuca `ArgumentException` z komunikatem `"Invalid discount code"`.
6. **Rabat jednorazowy 50%** — kupon z puli jednorazowych kodów udziela rabatu 50% (tylko raz).

## Nowa funkcja (do wdrożenia)

7. **Kupon HAPPYHOURS50** — w godzinach 14:00–16:00 udziela rabatu 50%. Poza tymi godzinami kupon nie działa (zachowanie jak błędny kod).

## Zadanie

1. Uruchom pakiet testów regresyjnych i upewnij się, że przechodzi.
2. Zaimplementuj obsługę kuponu `HAPPYHOURS50`.
3. Uruchom ponownie pakiet regresyjny — wszystkie testy muszą nadal przechodzić.
4. Dodaj test dla nowego kuponu.

## Przykładowy test

```cs
[Theory]
[InlineData(100, "SAVE10NOW", 90)]
[InlineData(100, "DISCOUNT20OFF", 80)]
[InlineData(100, "", 100)]
public void ExistingCoupons_ShouldStillWork(
    decimal price,
    string coupon,
    decimal expected)
{
}
```

## Cel

Ochrona przed regresją — nowa funkcjonalność nie może zepsuć tego, co już działa.

## Pytania do dyskusji

- Kiedy warto uruchamiać testy regresyjne?
- Czym różni się test regresyjny od testu jednostkowego?
- Jak zbudować pakiet regresyjny, który rośnie wraz z systemem?
- Co zrobić, gdy test regresyjny zacznie padać?
