# Use Case: Ważność kuponu rabatowego

## Opis

System zarządza kuponami rabatowymi w sklepie internetowym.

Każdy kupon ma datę wygaśnięcia. Klient może sprawdzić, czy kupon jest nadal ważny, zanim go użyje przy zamówieniu.

Implementacja korzysta bezpośrednio z `DateTime.UtcNow`, co utrudnia pisanie szybkich i deterministycznych testów.

## Reguły biznesowe

- Kupon jest ważny do momentu daty wygaśnięcia włącznie.
- Po upływie daty wygaśnięcia kupon jest uznawany za nieważny.
- Porównanie odbywa się w czasie UTC.

## Przykłady

| Data wygaśnięcia | „Teraz” (UTC) | IsExpired |
|------------------|---------------|-----------|
| jutro | dziś | false |
| wczoraj | dziś | true |
| dziś 23:59 | dziś 12:00 | false |
| dziś 12:00 | dziś 12:00 | false |
| dziś 12:00 | dziś 12:01 | true |

## Zadanie

Dla poniższych nazw testów zaimplementuj brakujący kod:

```cs
[Fact]
public void IsExpired_WhenExpirationIsTomorrow_ReturnsFalse()
{
    throw new NotImplementedException();
}

[Fact]
public void IsExpired_WhenExpirationIsYesterday_ReturnsTrue()
{
    throw new NotImplementedException();
}

[Fact]
public void IsExpired_WhenExpirationIsToday_ReturnsFalse()
{
    throw new NotImplementedException();
}

[Fact]
public void IsExpired_AtExactExpirationMoment_ReturnsFalse()
{
    throw new NotImplementedException();
}
```

Przed rozpoczęciem implementacji:

1. Uruchom testy i przeanalizuj, dlaczego trudno przetestować kupon ważny jutro.
2. Zidentyfikuj zależność od czasu w kodzie produkcyjnym.
3. Zaproponuj abstrakcję czasu, którą można zastąpić w testach.
4. Zrefaktoryzuj kod i zaimplementuj testy.

## Pytania do dyskusji

- Jak przetestować kupon ważny jutro?
- Dlaczego bezpośrednie użycie `DateTime.UtcNow` utrudnia testowanie?
- Jak kontrolować „aktualny moment” w teście?
- Czy abstrakcja czasu narusza zasadę YAGNI?
- Jakie konsekwencje ma wstrzykiwanie zależności od czasu w całej aplikacji?

## Wniosek

Kod zależny od aktualnego czasu wymaga abstrakcji, aby testy były szybkie i deterministyczne.

Wstrzyknięcie źródła czasu (np. `ITimeProvider`) pozwala w testach ustawić dowolny moment i weryfikować zachowanie systemu bez czekania.
