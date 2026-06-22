# Use Case: Monitor temperatury

## Opis

System monitoruje temperaturę w pomieszczeniu produkcyjnym.

Monitor posiada ustalony próg temperatury. Gdy zarejestrowana temperatura przekroczy ten próg, system powinien zgłosić alarm poprzez zdarzenie `TemperatureExceeded`.

## Reguły biznesowe

- Monitor powinien posiadać ustalony próg temperatury.
- Temperatura poniżej progu nie powinna wywoływać zdarzenia.
- Temperatura równa progowi nie powinna wywoływać zdarzenia.
- Temperatura powyżej progu powinna wywołać zdarzenie `TemperatureExceeded`.
- Zdarzenie powinno przekazywać zarejestrowaną temperaturę.

## Przykłady

| Próg | Zarejestrowana temperatura | Oczekiwany wynik |
|------|----------------------------|------------------|
| 25°C | 20°C | Brak zdarzenia |
| 25°C | 25°C | Brak zdarzenia |
| 25°C | 30°C | Zdarzenie `TemperatureExceeded` z temperaturą 30°C |

## Zadanie

Dla poniższych nazw testów zaimplementuj brakujący kod:

```cs
[Fact]
public void RecordTemperature_BelowThreshold_DoesNotRaiseEvent()
{
    throw new NotImplementedException();
}

[Fact]
public void RecordTemperature_AtThreshold_DoesNotRaiseEvent()
{
    throw new NotImplementedException();
}

[Fact]
public void RecordTemperature_AboveThreshold_RaisesTemperatureExceededEvent()
{
    throw new NotImplementedException();
}

[Fact]
public void RecordTemperature_AboveThreshold_PassesTemperatureInEventArgs()
{
    throw new NotImplementedException();
}
```

## Pytania do dyskusji

- Gdzie w teście należy subskrybować zdarzenie — w Arrange czy w Act?
- Jak zweryfikować, że zdarzenie nie zostało wywołane?
- Czy subskrypcja zdarzenia może należeć do sekcji Arrange?
- Czy wywołanie `RecordTemperature()` zawsze należy do sekcji Act?
- Jak przetestować argumenty przekazywane przez zdarzenie?

## Wniosek

Testowanie zdarzeń wymaga subskrypcji przed wykonaniem akcji, która je wywołuje.

Sekcje Arrange, Act i Assert nadal opisują intencję testu — subskrypcja zdarzenia i przygotowanie monitora to Arrange, rejestracja temperatury to Act, weryfikacja wywołania zdarzenia to Assert.
