# Use Case: Generator skróconych adresów URL

## Opis

System skraca długie adresy URL do krótkich kodów, np. `https://example.com/a1b2c3`.

Generator tworzy losowy ciąg znaków składający się z małych liter i cyfr. Domyślna długość kodu to 6 znaków.

Implementacja korzysta bezpośrednio z `Random`, co utrudnia pisanie deterministycznych testów.

## Reguły biznesowe

- Domyślna długość wygenerowanego kodu to 6 znaków.
- Kod może zawierać wyłącznie małe litery (a–z) i cyfry (0–9).
- Długość kodu można przekazać jako parametr.

## Przykłady

| Długość | Przykładowy wynik | Poprawny? |
|---------|-------------------|-----------|
| 6 (domyślna) | `a1b2c3` | Tak |
| 4 | `x9z1` | Tak |
| 6 | `A1B2C3` | Nie (wielkie litery niedozwolone) |
| 6 | `a1-b2` | Nie (myślnik niedozwolony) |

## Zadanie

Dla poniższych nazw testów zaimplementuj brakujący kod:

```cs
[Fact]
public void Generate_DefaultLength_ReturnsSixCharacters()
{
    throw new NotImplementedException();
}

[Fact]
public void Generate_ContainsOnlyAllowedCharacters()
{
    throw new NotImplementedException();
}

[Fact]
public void Generate_WithControlledRandom_ReturnsExpectedCode()
{
    throw new NotImplementedException();
}
```

Przed rozpoczęciem implementacji:

1. Uruchom testy i przeanalizuj, dlaczego trudno przewidzieć wynik generatora.
2. Zidentyfikuj zależność od losowości w kodzie produkcyjnym.
3. Zaproponuj abstrakcję generatora losowych wartości.
4. Zrefaktoryzuj kod i zaimplementuj testy.

## Pytania do dyskusji

- Dlaczego testy oparte na `Random` są niestabilne?
- Czy wystarczy uruchamiać test wielokrotnie, aby „sprawdzić losowość”?
- Jak przetestować konkretny wynik generatora?
- Kiedy warto wstrzyknąć abstrakcję losowości, a kiedy zaakceptować niedeterminizm?

## Wniosek

Kod zależny od losowości wymaga abstrakcji, aby testy były powtarzalne.

Wstrzyknięcie generatora losowych wartości pozwala w testach zwracać znane sekwencje i weryfikować logikę bez polegania na przypadku.
