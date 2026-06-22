# Use Case: Katalog produktów

## Opis

System udostępnia nazwę produktu z katalogu.

W tym ćwiczeniu chcemy przetestować, czy metoda zwraca poprawną nazwę produktu oraz jak reaguje na brak pliku lub pustą zawartość.

Implementacja odczytuje nazwę bezpośrednio z pliku, co utrudnia pisanie szybkich i deterministycznych testów jednostkowych.

## Problem

Początkowa implementacja odczytuje nazwę produktu bezpośrednio z pliku:

```cs
public string GetProductName()
{
    return File.ReadAllText("product.txt");
}
```

Taki kod utrudnia testowanie, ponieważ test metody `GetProductName()` wymaga istnienia pliku `product.txt` w katalogu roboczym.

## Reguły biznesowe

- Metoda `GetProductName()` powinna zwracać nazwę produktu.
- Gdy plik nie istnieje, metoda powinna rzucić wyjątek.
- Gdy plik jest pusty lub zawiera wyłącznie białe znaki, metoda powinna rzucić wyjątek.
- Test zwracanej wartości nie powinien zależeć od systemu plików.

## Zadanie

Dla poniższych nazw testów zaimplementuj brakujący kod:

```cs
[Fact]
public void GetProductName_ValidFile_ReturnsProductName()
{
    throw new NotImplementedException();
}

[Fact]
public void GetProductName_EmptyFile_ThrowsException()
{
    throw new NotImplementedException();
}

[Fact]
public void GetProductName_WhitespaceFile_ThrowsException()
{
    throw new NotImplementedException();
}

[Fact]
public void GetProductName_FileDoesNotExist_ThrowsException()
{
    throw new NotImplementedException();
}
```

Przed rozpoczęciem implementacji:

1. Uruchom testy i przeanalizuj, od czego zależy ich wynik.
2. Zidentyfikuj zależność od systemu plików w kodzie produkcyjnym.
3. Zaproponuj abstrakcję odczytu pliku, którą można zastąpić w testach.
4. Zrefaktoryzuj kod i zaimplementuj testy.

## Pytania do dyskusji

- Co musi istnieć, aby test przeszedł?
- Co jeśli pliku nie ma?
- Co jeśli ktoś zmieni jego zawartość?
- Czy test zależy od systemu plików?
- Jak przetestować różne scenariusze odczytu pliku bez tworzenia plików na dysku?
- Jakie konsekwencje ma izolacja od systemu plików dla niezawodności testów?

## Wniosek

Kod zależny od systemu plików wymaga abstrakcji, aby testy były szybkie i niezależne od infrastruktury.

Wstrzyknięcie źródła odczytu pliku pozwala w testach zwracać kontrolowane odpowiedzi i weryfikować logikę bez tworzenia plików w katalogu roboczym.
