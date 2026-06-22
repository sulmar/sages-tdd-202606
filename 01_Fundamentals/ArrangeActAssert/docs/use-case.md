# Use Case: Koszyk zakupowy

## Opis

System sklepu internetowego umożliwia klientowi dodawanie i usuwanie produktów z koszyka.

Każdy nowo utworzony koszyk powinien zapamiętać datę i czas swojego utworzenia.

Klient może w dowolnym momencie sprawdzić łączną wartość produktów znajdujących się w koszyku.

## Reguły biznesowe

- Nowy koszyk powinien posiadać datę utworzenia.
- Pusty koszyk powinien mieć wartość 0.
- Po dodaniu jednego produktu wartość koszyka powinna być równa cenie produktu.
- Po dodaniu wielu produktów wartość koszyka powinna być sumą ich cen.
- Po usunięciu produktu wartość koszyka powinna zostać pomniejszona o jego cenę.
- Po usunięciu ostatniego produktu wartość koszyka powinna wynosić 0.

## Przykłady

| Operacja | Oczekiwany wynik |
|----------|------------------|
| Utworzenie koszyka | Ustawiona data utworzenia |
| Pusty koszyk | 0 |
| Dodanie produktu za 100 zł | 100 |
| Dodanie produktów za 100 zł i 200 zł | 300 |
| Dodanie produktów za 3000 zł, 100 zł i 200 zł | 3300 |
| Usunięcie produktu za 200 zł z koszyka o wartości 300 zł | 100 |
| Usunięcie ostatniego produktu z koszyka | 0 |

## Zadanie

Dla poniższych nazw testów zaimplementuj brakujący kod:

```cs
[Fact]
public void Constructor_NewCart_SetsCreationDate()
{
    throw new NotImplementedException();
}
[Fact]
public void CalculateTotal_SingleProduct_ReturnsProductPrice()
{
    throw new NotImplementedException();
}
[Fact]
public void CalculateTotal_MultipleProducts_ReturnsSum()
{
    throw new NotImplementedException();
}
[Fact]
public void RemoveProduct_ExistingProduct_DecreasesTotal()
{
    throw new NotImplementedException();
}
[Fact]
public void RemoveProduct_LastRemainingProduct_ReturnsZeroTotal()
{
    throw new NotImplementedException();
}
```

## Pytania do dyskusji

- Czy konstruktor zawsze należy do sekcji Arrange?
- Czy metoda biznesowa zawsze należy do sekcji Act?
- Czy w sekcji Arrange można wywoływać metody biznesowe?
- Czy w sekcji Arrange może znajdować się więcej niż jedno wywołanie metody?
- Dlaczego `AddProduct()` może znaleźć się w Arrange?
- Dlaczego `RemoveProduct()` może znaleźć się w Act?
- Jak rozpoznać, które zachowanie jest przedmiotem testu?

## Wniosek

Arrange, Act i Assert opisują intencję kodu, a nie rodzaj instrukcji.

Ta sama instrukcja może znaleźć się w sekcji Arrange lub Act w zależności od tego, jakie zachowanie jest testowane.
