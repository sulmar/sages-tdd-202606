# Use Case: Katalog produktów

## Opis

System udostępnia nazwę produktu z katalogu.

W tym ćwiczeniu chcemy przetestować, czy metoda zwraca poprawną nazwę produktu.

Nie chcemy, aby test zależał od systemu plików.

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
- Test zwracanej wartości nie powinien zależeć od systemu plików.

## Zadanie

Uruchom test i przeanalizuj jego zależności.

Następnie zrefaktoryzuj kod tak, aby odczyt pliku można było zastąpić w teście.

Zaimplementuj stub, który zwraca ustaloną nazwę produktu:

```cs
[Fact]
public void GetProductName_ReturnsProductName()
{
    var catalog = new ProductCatalog();

    var name = catalog.GetProductName();

    Assert.Equal("Coffee", name);
}
```

## Pytania do uczestników

- Co musi istnieć, aby test przeszedł?
- Co jeśli pliku nie ma?
- Co jeśli ktoś zmieni jego zawartość?
- Czy test zależy od systemu plików?

## Wniosek

Stub to obiekt, który zwraca ustalone odpowiedzi na wywołania metod.

Każdy Stub steruje zachowaniem zależności w inny sposób, ale żaden nie przechowuje danych (Fake), nie rejestruje wywołań (Spy) i nie weryfikuje oczekiwań (Mock).

Test korzysta ze stuba, aby odizolować weryfikację wartości zwracanej przez testowany kod od zewnętrznej infrastruktury.
