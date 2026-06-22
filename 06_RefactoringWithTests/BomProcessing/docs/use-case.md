# Use Case: Przetwarzanie BOM

## Opis

System przetwarza listę materiałową (BOM) konstrukcji wystawienniczej.

Elementy BOM to profile, słupki i taśmy LED. System oblicza koszt, wagę i generuje listy produkcyjne oraz zakupowe.

Struktura elementów BOM jest stabilna — nowe operacje pojawiają się częściej niż nowe typy elementów.

## Reguły biznesowe

### Koszt

| Typ elementu | Wzór |
|--------------|------|
| Profile | długość (m) × 100 |
| Column | wysokość (m) × 150 |
| LedStrip | długość (m) × 40 |

### Waga

| Typ elementu | Wzór |
|--------------|------|
| Profile | długość (m) × 2,5 kg |
| Column | wysokość (m) × 4,0 kg |
| LedStrip | długość (m) × 0,2 kg |

## Przykłady

| Element | Wymiar | Koszt | Waga |
|---------|--------|-------|------|
| Profile „P1" | 2 m | 200 | 5,0 kg |
| Column „C1" | 3 m | 450 | 12,0 kg |
| LedStrip „L1" | 5 m | 200 | 1,0 kg |

## Implementacja

```cs
public abstract class BomItem
{
    public string Name { get; }

    protected BomItem(string name)
    {
        Name = name;
    }
}

public class Profile : BomItem
{
    public decimal LengthInMeters { get; }

    public Profile(string name, decimal lengthInMeters)
        : base(name)
    {
        LengthInMeters = lengthInMeters;
    }
}

public class Column : BomItem
{
    public decimal HeightInMeters { get; }

    public Column(string name, decimal heightInMeters)
        : base(name)
    {
        HeightInMeters = heightInMeters;
    }
}

public class LedStrip : BomItem
{
    public decimal LengthInMeters { get; }

    public LedStrip(string name, decimal lengthInMeters)
        : base(name)
    {
        LengthInMeters = lengthInMeters;
    }
}
```

```cs
public class BomProcessor
{
    public decimal CalculateCost(IEnumerable<BomItem> items)
    {
        decimal total = 0;

        foreach (var item in items)
        {
            if (item is Profile profile)
            {
                total += profile.LengthInMeters * 100;
            }
            else if (item is Column column)
            {
                total += column.HeightInMeters * 150;
            }
            else if (item is LedStrip ledStrip)
            {
                total += ledStrip.LengthInMeters * 40;
            }
        }

        return total;
    }

    public decimal CalculateWeight(IEnumerable<BomItem> items)
    {
        decimal total = 0;

        foreach (var item in items)
        {
            if (item is Profile profile)
            {
                total += profile.LengthInMeters * 2.5m;
            }
            else if (item is Column column)
            {
                total += column.HeightInMeters * 4.0m;
            }
            else if (item is LedStrip ledStrip)
            {
                total += ledStrip.LengthInMeters * 0.2m;
            }
        }

        return total;
    }
}
```

## Zadanie

Masz działające testy i monolityczny procesor BOM.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: każda nowa operacja powtarza ten sam łańcuch if/else.

## Pytania do dyskusji

- Co dzieje się z `BomProcessor` po dodaniu `GenerateCuttingList()` lub `GeneratePurchaseList()`?
- Czy każda operacja powinna znać wszystkie typy elementów BOM?
- Jak testować poszczególne operacje w izolacji?
- Jak dodać nową operację bez modyfikacji istniejących metod?

## Ból

- Każda nowa operacja na BOM powtarza ten sam if/else
- `CalculateCost()`, `CalculateWeight()`, `GenerateCuttingList()`, `GeneratePurchaseList()` — wszystkie muszą znać typy elementów BOM
- Rosnąca liczba miejsc wymagających modyfikacji przy dodaniu nowej operacji

## Wniosek

Wraz ze wzrostem liczby operacji na tej samej strukturze danych rośnie powtarzalność i ryzyko błędów.

Testy pozwalają bezpiecznie przenieść logikę operacji do osobnych visitorów i rozdzielić odpowiedzialności we wzorcu **Visitor**.
