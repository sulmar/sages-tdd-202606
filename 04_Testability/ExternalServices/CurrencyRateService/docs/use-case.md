# Use Case: Przeliczanie walut

## Opis

System przelicza kwoty między walutami na podstawie kursu pobieranego z zewnętrznego API.

Serwis wysyła żądanie HTTP, odczytuje kurs z odpowiedzi JSON i mnoży kwotę przez kurs wymiany.

Bezpośrednie wywołanie HTTP utrudnia pisanie szybkich testów jednostkowych — test wymagałby działającego API lub połączenia sieciowego.

## Reguły biznesowe

- Kurs wymiany jest pobierany z zewnętrznego API.
- Odpowiedź API zawiera pole `rate` z kursem wymiany.
- Przeliczona kwota = kwota wejściowa × kurs wymiany.

## Przykłady

| Kwota | Z | Na | Kurs | Wynik |
|-------|---|----|------|-------|
| 100 | PLN | EUR | 0.23 | 23.00 |
| 50 | EUR | PLN | 4.30 | 215.00 |

Format odpowiedzi API:

```json
{ "rate": 0.23 }
```

## Zadanie

Dla poniższych nazw testów zaimplementuj brakujący kod:

```cs
[Fact]
public async Task GetRate_ParsesApiResponse()
{
    throw new NotImplementedException();
}

[Fact]
public async Task Convert_UsesRateFromApi()
{
    throw new NotImplementedException();
}
```

Przed rozpoczęciem implementacji zastanów się:

- Co jest trudne do przetestowania w tej klasie?
- Od czego zależy wynik testu?
- Czy test będzie zawsze zwracał ten sam wynik?
- Czy test wymaga infrastruktury zewnętrznej?

## Pytania do dyskusji

- Która klasa odpowiada za przeliczanie walut?
- Która klasa odpowiada za pobieranie kursów?
- Czy te odpowiedzialności powinny znajdować się w jednej klasie?
- Dlaczego testy jednostkowe nie powinny wymagać połączenia sieciowego?
- Jak przetestować kod korzystający z `HttpClient` bez prawdziwego serwera?
- Jakie konsekwencje ma izolacja od usług zewnętrznych dla niezawodności testów?

## Wniosek

Kod zależny od usług zewnętrznych wymaga izolacji, aby testy były szybkie i niezależne od infrastruktury.

Zastąpienie bezpośredniego wywołania HTTP kontrolowaną zależnością pozwala w testach zwracać znane odpowiedzi i weryfikować logikę przeliczania.
