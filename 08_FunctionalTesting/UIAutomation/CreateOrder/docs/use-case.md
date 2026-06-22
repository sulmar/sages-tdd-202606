# Use Case: Składanie zamówienia przez interfejs użytkownika

## Pytanie

Czy klient może zrealizować proces biznesowy przez aplikację?

## Opis

Klient składa zamówienie na produkt **Coffee** przez sklep internetowy — tak jak robi to prawdziwy użytkownik w przeglądarce.

## Ten sam proces biznesowy

W obu przypadkach testujesz ten sam proces biznesowy:

```
Wybierz produkt
        ↓
Dodaj do koszyka
        ↓
Wypełnij formularz
        ↓
Złóż zamówienie
        ↓
Otrzymaj potwierdzenie
```

## Różnica

```
EndToEndTesting
        ↓
wywołuje Use Case bezpośrednio

UIAutomation
        ↓
steruje aplikacją jak użytkownik
```

## Scenariusz

```
Otwórz sklep
        ↓
Wybierz produkt
        ↓
Dodaj do koszyka
        ↓
Wypełnij formularz
        ↓
Kliknij "Złóż zamówienie"
        ↓
Sprawdź potwierdzenie
```

## Oczekiwany wynik

| Element | Wartość |
|---------|---------|
| Produkt | Coffee, 100 zł |
| Status | Zamówienie utworzone |

## Test UI

```cs
[Fact]
public async Task Customer_Can_Create_Order()
{
    // otwórz sklep

    // wybierz produkt

    // dodaj do koszyka

    // wypełnij formularz

    // kliknij "Złóż zamówienie"

    // sprawdź potwierdzenie
}
```

## Cel

Test UI Automation weryfikuje proces biznesowy od strony użytkownika — przez przeglądarkę, bez bezpośredniego wywoływania use case'u w teście.

## Pytania do dyskusji

- Dlaczego ten sam scenariusz można testować na dwóch poziomach?
- Kiedy test UI ma sens, a kiedy wystarczy test E2E?
- Dlaczego testy UI są wolniejsze i bardziej kruche?
- Jakie selektory warto stosować w testach UI?
