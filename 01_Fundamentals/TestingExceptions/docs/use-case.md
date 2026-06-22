# Use Case: Wykorzystanie karty podarunkowej

## Opis

System obsługuje karty podarunkowe, które mają określone saldo.

Klient może wykorzystać środki z karty podarunkowej podczas płatności za zamówienie.

System powinien zmniejszyć saldo karty o wykorzystaną kwotę, ale tylko wtedy, gdy operacja jest poprawna.

## Reguły biznesowe

| Warunek | Oczekiwany wynik |
|--------|------------------|
| Kwota jest większa od 0 i nie przekracza salda | Saldo zostaje pomniejszone |
| Kwota jest równa saldu | Saldo zostaje pomniejszone do 0 |
| Kwota jest większa niż saldo | Zgłoszony zostaje błąd |
| Kwota jest równa 0 | Zgłoszony zostaje błąd |
| Kwota jest ujemna | Zgłoszony zostaje błąd |

## Przykłady

| Saldo początkowe | Kwota wykorzystania | Oczekiwany wynik |
|------------------|---------------------|------------------|
| 100 zł | 40 zł | Saldo: 60 zł |
| 100 zł | 100 zł | Saldo: 0 zł |
| 100 zł | 150 zł | `InvalidOperationException` |
| 100 zł | 0 zł | `ArgumentException` |
| 100 zł | -10 zł | `ArgumentException` |

## Zadanie

Napisz testy dla metody:

```cs
public void Redeem(decimal amount)
```

## Scenariusze testowe

Zaproponuj i zaimplementuj testy zgodne z konwencją:

```{Method}_{Scenario}_{ExpectedBehavior}```

Przykładowe nazwy:

```cs
Redeem_AmountLessThanBalance_DecreasesBalance

Redeem_AmountEqualToBalance_DecreasesBalanceToZero

Redeem_AmountGreaterThanBalance_ThrowsInvalidOperationException

Redeem_ZeroAmount_ThrowsArgumentException

Redeem_NegativeAmount_ThrowsArgumentException
```

## Pytania do dyskusji

- Czym różni się błędny argument od błędnej operacji?
- Kiedy użyć `ArgumentException`, a kiedy `InvalidOperationException`?
- Czy warto testować komunikat wyjątku?
- Czy `Redeem(0)` powinno być dozwolone?
- Skąd programista ma wiedzieć, jak system powinien zachować się dla wartości 0?