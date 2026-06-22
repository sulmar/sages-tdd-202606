# Use Case: Drukarka legacy

## Opis

System drukuje dokumenty.

Nowe API obsługuje wielokrotne kopie dokumentu. W produkcji musimy korzystać ze starej drukarki (`LegacyPrinter`), której nie możemy modyfikować.

## Reguły biznesowe

- Drukarka wypisuje treść dokumentu na standardowe wyjście.
- Nowe API przyjmuje liczbę kopii do wydrukowania.
- Stare API obsługuje tylko pojedynczy wydruk jednego dokumentu.

## Przykłady

| Dokument | Kopie | Wynik |
|----------|-------|-------|
| `Invoice #42` | 1 | `Invoice #42` |
| `Invoice #42` | 3 | `Invoice #42`, `Invoice #42`, `Invoice #42` |
| `Invoice #42` | 0 | brak wydruku |

## Implementacja

```cs
public class NewPrinter
{
    public void PrintDocument(string document, int copies)
    {
        for (int i = 0; i < copies; i++)
        {
            Console.WriteLine(document);
        }
    }
}
```

```cs
public class LegacyPrinter // nie możemy jej modyfikować!
{
    public void PrintDocument(string document)
    {
        Console.WriteLine(document);
    }
}
```

## Zadanie

Masz działające testy i `NewPrinter`, który samodzielnie realizuje drukowanie.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: zduplikowana logika drukowania, niekompatybilne API, konieczność użycia `LegacyPrinter`.

## Pytania do dyskusji

- Jak użyć `LegacyPrinter` tam, gdzie oczekiwane jest nowe API?
- Czy modyfikacja `LegacyPrinter` jest możliwa? Jakie są konsekwencje?
- Gdzie powinna żyć logika obsługi wielu kopii?

## Ból

- Niekompatybilne interfejsy (brak parametru `copies` w legacy)
- Zduplikowana logika drukowania
- Niemożność modyfikacji kodu legacy


