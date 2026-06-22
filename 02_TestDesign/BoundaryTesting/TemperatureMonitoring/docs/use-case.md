## Use Case: Monitorowanie temperatury kotła

## Opis

System monitoruje temperaturę wody w kotle przemysłowym.

Na podstawie zmierzonej temperatury system wyświetla operatorowi kolor informujący o aktualnym stanie urządzenia.

Przy temperaturze zbliżonej do temperatury wrzenia wody operator powinien otrzymać ostrzeżenie. Po osiągnięciu lub przekroczeniu temperatury wrzenia system powinien zgłosić stan krytyczny.

## Reguły biznesowe

| Zakres temperatury | Oczekiwany wynik |
|-------------------|------------------|
| poniżej 80°C | Green (🟢) |
| od 80°C do 99°C | Orange (🟠) |
| od 100°C wzwyż | Red (🔴) |

## Przykłady

| Temperatura | Wynik |
|------------|--------|
| 25°C | Green (🟢) |
| 79°C | Green (🟢) |
| 80°C | Orange (🟠) |
| 99°C | Orange (🟠) |
| 100°C | Red (🔴) |
| 120°C | Red (🔴) |

Zadanie

Napisz testy dla metody:

public string SignalColor(double temperature)

Przed rozpoczęciem implementacji:

1. Zidentyfikuj wartości graniczne.
2. Zaproponuj nazwy testów.
3. Wskaż sekcje Arrange, Act i Assert.
4. Zastanów się, które przypadki testowe dają największą wartość.

Pytania do dyskusji

* Czy wszystkie przedziały zostały poprawnie zdefiniowane?
* Jakie wartości znajdują się na granicy przedziałów?
* Czy wystarczy przetestować temperatury: 25°C, 50°C i 120°C?
* Jakie testy dają największą pewność poprawności implementacji?


## Dodatkowe wymagania

W przypadku wystąpienia stanu krytycznego system powinien dodatkowo wysłać alert do obsługi technicznej.