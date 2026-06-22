# Use Case: Program lojalnościowy

## Opis

Sklep internetowy prowadzi program lojalnościowy.

Każdy klient posiada konto punktowe. Punkty można:

* dodawać,
* wykorzystać podczas zakupów,
* sprawdzić aktualne saldo.

System nie pozwala wykorzystać większej liczby punktów niż aktualnie posiada klient.

## Zadanie

Utwórz konto _LoyaltyAccount_ z metodami _Add_, _Redeem_ i _Balance_ do zarządzania punktami lojalnościowymi według poniższych wymagań.

## Reguły biznesowe

* Nowe konto posiada 0 punktów.
* Można dodać dowolną dodatnią liczbę punktów.
* Wykorzystanie punktów zmniejsza saldo.
* Nie można wykorzystać więcej punktów niż dostępne saldo.
* Próba wykorzystania zbyt dużej liczby punktów powoduje wyjątek `InvalidOperationException`.

## Przykłady

| Saldo początkowe | Operacja     | Wynik    |
|------------------|--------------|----------|
| 0                | Add(100)     | 100      |
| 100              | Redeem(40)   | 60       |
| 50               | Redeem(50)   | 0        |
| 50               | Redeem(60)   | wyjątek  |

## Wymagania niefunkcjonalne

- Wymagania realizuj zgodnie z techniką **TDD** (_Test-driven-development_):
  - **Red** - kod nieprzechodzący test
  - **Green** - kod przechodzący test
  - **Refactor** - refaktoryzacja kodu i testów
- Kod powinien być czytelny i łatwy do dalszego rozwoju
