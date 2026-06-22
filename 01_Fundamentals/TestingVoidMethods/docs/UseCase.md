# Use Case: Kamera przemysłowa

## Opis

System steruje kamerą przemysłową wykonującą zdjęcia produktów na linii produkcyjnej.

Każde wykonane zdjęcie otrzymuje unikalną nazwę zawierającą numer sekwencyjny.

Po wykonaniu zdjęcia system powinien zapamiętać nazwę ostatnio wykonanego zdjęcia.

W przyszłości zdjęcia będą zapisywane do zewnętrznego magazynu plików, np. na dysku, Amazon S3 lub Cloudflare R2.

## Przykłady

| Operacja | Oczekiwany rezultat |
|-----------|--------------------|
| Pierwsze zdjęcie | `img_seq_0001.jpg` |
| Drugie zdjęcie | `img_seq_0002.jpg` |
| Trzecie zdjęcie | `img_seq_0003.jpg` |

## Zadanie

Napisz testy dla metody:

```cs
void TakePicture()
```

Przed rozpoczęciem implementacji:

1. Zaproponuj nazwy testów.
2. Wskaż sekcje Arrange, Act i Assert.
3. Zastanów się, jak przetestować metodę, która nic nie zwraca.
4. Jakie informacje o stanie obiektu można zweryfikować po wykonaniu operacji?