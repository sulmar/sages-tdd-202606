# Use Case: Katalog produktów

## Opis

System udostępnia produkty z katalogu.

Kontroler pobiera produkty z repozytorium i cache'uje wyniki, aby ograniczyć liczbę odczytów z bazy danych.

W kolejnych iteracjach system będzie rozszerzany o nowe wymagania dotyczące cache.

## Reguły biznesowe

### Iteracja 1

Nie pobieraj tego samego produktu dwa razy — kolejne wywołanie `Get` dla tego samego identyfikatora zwraca produkt z cache bez odpytywania repozytorium.

### Iteracja 2

Chcemy liczyć trafienia cache — każde pobranie produktu z cache zwiększa licznik `CacheHits`.

## Przykłady

### Iteracja 1

| Wywołania | Odczyty z repozytorium |
|-----------|------------------------|
| `Get(1)`, `Get(1)` | 1 |
| `Get(1)`, `Get(2)` | 2 |

### Iteracja 2

| Wywołania | CacheHits |
|-----------|-----------|
| `Get(1)` | 0 |
| `Get(1)`, `Get(1)` | 1 |
| `Get(1)`, `Get(1)`, `Get(1)` | 2 |

## Implementacja

```cs
public record Product(
    int Id,
    string Name);
```

```cs
public interface IProductRepository
{
    Product Get(int id);
}
```

```cs
public class ProductsController
{
    private readonly IProductRepository _repository;
    private readonly Dictionary<int, Product> _cache = [];
    private int _cacheHits;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    public int CacheHits => _cacheHits;

    public Product Get(int id)
    {
        if (_cache.TryGetValue(id, out var product))
        {
            _cacheHits++;
            return product;
        }

        product = _repository.Get(id);
        _cache[id] = product;
        return product;
    }
}
```

## Zadanie

Masz działające testy i monolityczną metodę `Get`.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: logika pobierania produktu, cache i licznik trafień w jednej klasie.

## Pytania do dyskusji

- Co dzieje się z metodą `Get` po dodaniu kolejnego wymagania dotyczącego cache?
- Czy kontroler powinien odpowiadać za cache i liczenie trafień?
- Jak testować zachowanie cache w izolacji od kontrolera?
- Jak wydzielić cache do osobnego proxy repozytorium?

## Ból

- Kolejne wymagania cache = kolejne warunki w metodzie
- Mieszanie odpowiedzialności kontrolera i cache
- Trudne rozszerzanie o nowe zachowania (np. wygasanie cache)

## Wniosek

Wraz ze wzrostem liczby wymagań dotyczących cache rośnie złożoność metody pobierającej produkt.

Testy pozwalają bezpiecznie wydzielić cache do osobnej klasy proxy implementującej `IProductRepository` we wzorcu **Proxy**.
