# Use Case: Porównywanie lokalizacji GPS

## Opis

System śledzi lokalizację pojazdów w transporcie miejskim.

Każda lokalizacja jest reprezentowana przez obiekt `GpsLocation` zawierający współrzędne geograficzne: szerokość i długość geograficzną.

Podczas testowania system często trzeba sprawdzić, czy dwie lokalizacje reprezentują ten sam punkt na mapie — nawet jeśli są to różne instancje obiektów w pamięci.

## Reguły biznesowe

- Dwie lokalizacje z tymi samymi współrzędnymi powinny być uznawane za równe.
- Lokalizacje z różną szerokością geograficzną nie powinny być równe.
- Lokalizacje z różną długością geograficzną nie powinny być równe.

## Przykłady

| Lokalizacja 1 | Lokalizacja 2 | Oczekiwany wynik |
|---------------|---------------|------------------|
| 52.2297, 21.0122 | 52.2297, 21.0122 | Równe |
| 52.2297, 21.0122 | 50.0647, 21.0122 | Różne |
| 52.2297, 21.0122 | 52.2297, 19.9450 | Różne |

## Zadanie

Dla poniższych nazw testów zaimplementuj brakujący kod:

```cs
[Fact]
public void GpsLocation_SameCoordinates_AreEqual()
{
    var loc1 = new GpsLocation(52.2297, 21.0122);
    var loc2 = new GpsLocation(52.2297, 21.0122);

    Assert.Equal(loc1, loc2);
}

[Fact]
public void GpsLocation_DifferentLatitude_AreNotEqual()
{
    throw new NotImplementedException();
}

[Fact]
public void GpsLocation_DifferentLongitude_AreNotEqual()
{
    throw new NotImplementedException();
}
```

Przed rozpoczęciem implementacji:

1. Uruchom test `GpsLocation_SameCoordinates_AreEqual` i przeanalizuj wynik.
2. Zastanów się, dlaczego dwa obiekty z tymi samymi danymi mogą nie być równe.
3. Zaproponuj sposób naprawy testu.
4. Zaimplementuj pozostałe scenariusze testowe.

## Pytania do dyskusji

- Czym różni się równość referencyjna od równości wartościowej?
- Jak `Assert.Equal` porównuje obiekty?
- Kiedy warto nadpisać `Equals` i `GetHashCode`?
- Czy wystarczy porównać poszczególne właściwości zamiast całego obiektu?
- Jakie są konsekwencje braku poprawnej implementacji równości w kolekcjach?

## Wniosek

`Assert.Equal` dla obiektów korzysta z metody `Equals`, a nie z operatora `==`.

Dla typów referencyjnych domyślna implementacja porównuje referencje, a nie zawartość obiektu. Aby testować równość wartościową, klasa musi poprawnie implementować równość obiektów.
