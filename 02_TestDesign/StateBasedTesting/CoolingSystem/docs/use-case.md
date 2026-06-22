# Use Case: Sterowanie układem chłodzenia z wykorzystaniem histerezy

## Opis

System monitoruje temperaturę urządzenia przemysłowego i steruje układem chłodzenia.

Gdy temperatura jest wysoka, chłodzenie powinno zostać włączone. Gdy temperatura spadnie, chłodzenie powinno zostać wyłączone.

Aby uniknąć ciągłego włączania i wyłączania chłodzenia przy temperaturach bliskich wartości granicznej, system wykorzystuje **histerezę**.

## Co to jest histereza?

Histereza oznacza, że próg włączenia i wyłączenia urządzenia nie jest taki sam.

W tym przykładzie:

- chłodzenie włącza się przy temperaturze `30°C` lub wyższej,
- chłodzenie wyłącza się dopiero przy temperaturze `25°C` lub niższej.

Dzięki temu niewielkie wahania temperatury nie powodują ciągłych zmian stanu urządzenia.

Przykład bez histerezy:

```
29°C → OFF
30°C → ON
29°C → OFF
30°C → ON
29°C → OFF
```

Układ nieustannie przełącza się pomiędzy stanami.

Przykład z histerezą:

```
30°C → ON
29°C → ON
28°C → ON
27°C → ON
26°C → ON
25°C → OFF
```

Stan pozostaje stabilny.

## Reguły biznesowe

| Aktualny stan | Temperatura | Nowy stan |
|---------------|-------------|------------|
| Off | >= 30°C | On |
| Off | < 30°C | Off |
| On | > 25°C | On |
| On | <= 25°C | Off |

## Przykłady

| Stan początkowy | Temperatura | Stan końcowy |
|-----------------|-------------|--------------|
| Off | 20°C | Off |
| Off | 29°C | Off |
| Off | 30°C | On |
| On | 29°C | On |
| On | 28°C | On |
| On | 26°C | On |
| On | 25°C | Off |

## Zadanie

Napisz testy dla metody:

```cs
public void Update(double temperature)
```

Przed rozpoczęciem implementacji:

1. Zidentyfikuj możliwe stany systemu.
2. Zidentyfikuj możliwe przejścia pomiędzy stanami.
3. Zaproponuj scenariusze testowe.
4. Zastanów się, czy sama temperatura wystarcza do określenia oczekiwanego wyniku.

## Pytania do dyskusji

- Czy temperatura 28°C zawsze prowadzi do tego samego wyniku?
- Dlaczego sama temperatura nie wystarcza do określenia wyniku?
- Jakie stany może przyjmować układ chłodzenia?
- Jakie przejścia pomiędzy stanami są możliwe?
- Jakie błędy mogłyby wystąpić, gdyby histereza nie została zaimplementowana?

## Wniosek

W przypadku systemów posiadających stan często nie wystarczy testowanie wartości wejściowych i wartości granicznych.

Należy również uwzględnić aktualny stan systemu oraz możliwe przejścia pomiędzy stanami. Takie podejście nazywamy State Based Testing.
