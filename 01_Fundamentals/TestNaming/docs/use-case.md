# Use Case: Kontrola dostępu do budynku

## Opis

System kontroli dostępu zarządza wejściem pracowników do budynku.

Każdy pracownik posiada kartę dostępu (Badge), która może być aktywna lub nieaktywna.

Przed otwarciem drzwi system powinien sprawdzić status karty i zdecydować, czy użytkownik może wejść do budynku.

## Reguły biznesowe

| Status karty | Oczekiwany wynik |
|--------------|------------------|
| Aktywna | Dostęp przyznany |
| Nieaktywna | Dostęp odrzucony |

## Przykłady

| Status karty | Wynik |
|--------------|-------|
| Aktywna | true |
| Nieaktywna | false |

## Zadanie

Dla metody:

```cs
public bool CanEnter(Badge badge)
```

1. Zaproponuj nazwy testów.
2. Wskaż sekcje Arrange, Act i Assert.
3. Zaimplementuj testy.
4. Oceń, czy nazwy testów jednoznacznie opisują scenariusz i oczekiwany rezultat.

## Pytania do dyskusji

- Czy nazwa testu powinna opisywać implementację czy zachowanie biznesowe?
- Która nazwa jest bardziej czytelna?
  - `CanEnter_ValidBadge_ReturnsTrue()`
  - `CanEnter_ActiveBadge_ReturnsTrue()`
