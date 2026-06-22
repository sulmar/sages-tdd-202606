# Use Case: Anulowanie rezerwacji

## Opis

System umożliwia użytkownikom tworzenie i zarządzanie rezerwacjami.

## Reguły biznesowe

1. Administrator może anulować każdą rezerwację.
2. Właściciel rezerwacji może anulować własną rezerwację.
3. Pozostali użytkownicy nie mogą anulować rezerwacji.
4. Próba sprawdzenia uprawnień dla niezdefiniowanego użytkownika jest błędem.

## Zadanie

Dla metody:

```cs
Reservation.CanCancel(User user)
```

1. Wypisz wszystkie scenariusze testowe, które wynikają z reguł biznesowych.
2. Dla każdego scenariusza zaproponuj nazwę testu.
3. Zaimplementuj testy.

## Pytania do dyskusji

- Jak przełożyć reguły biznesowe na scenariusze testowe?
- Jakie ścieżki wykonania ma metoda `CanCancel`?
- Czy każda ścieżka w kodzie wymaga osobnego testu?
- Czy każda reguła biznesowa wymaga osobnego testu?
- Jak rozpoznać, że scenariusz został pominięty?
- Jak sprawdzić, że lista scenariusów jest kompletna?

## Wniosek

Scenariusze testowe wynikają z reguł biznesowych i ścieżek wykonania kodu.

Zanim zbudujesz test (Arrange, Act, Assert), musisz wiedzieć, co testujesz.
