# Use Case: Rejestracja klienta

## Opis

System umożliwia rejestrację nowych klientów.

Przed utworzeniem konta dane klienta powinny zostać zweryfikowane przez zestaw reguł biznesowych.

W kolejnych iteracjach system będzie rozszerzany o nowe reguły walidacyjne.

## Reguły biznesowe

### Iteracja 1

- Klient musi podać adres e-mail.

### Iteracja 2

- Klient musi być pełnoletni.

### Iteracja 3

- Klient musi zaakceptować regulamin.

### Iteracja 4

- Klient musi być rezydentem kraju.

## Przykłady

### Iteracja 1

| Email | Oczekiwany wynik |
|-------|------------------|
| "" | Niepoprawny klient |
| "john@example.com" | Poprawny klient |

### Iteracja 2

| Email | Wiek | Oczekiwany wynik |
|-------|------|------------------|
| "john@example.com" | 17 | Niepoprawny klient |
| "john@example.com" | 18 | Poprawny klient |

### Iteracja 3

| Email | Wiek | Regulamin zaakceptowany | Oczekiwany wynik |
|-------|------|-------------------------|------------------|
| "john@example.com" | 25 | Nie | Niepoprawny klient |
| "john@example.com" | 25 | Tak | Poprawny klient |

### Iteracja 4

| Email | Wiek | Regulamin zaakceptowany | Rezydent | Oczekiwany wynik |
|-------|------|-------------------------|----------|------------------|
| "john@example.com" | 25 | Tak | Nie | Niepoprawny klient |
| "john@example.com" | 25 | Tak | Tak | Poprawny klient |

## Implementacja

```cs
public record Customer(
    int Id,
    string Email,
    int Age,
    bool AcceptedTerms,
    bool IsDomestic);
```

```cs
public class CustomerValidator
{
    public bool Validate(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Email))
            return false;

        if (customer.Age < 18)
            return false;

        if (!customer.AcceptedTerms)
            return false;

        if (!customer.IsDomestic)
            return false;

        return true;
    }
}
```

Kontroler przyjmuje tylko jeden walidator:

```cs
public class CustomersController
{
    public ActionResult Post(CustomerValidator validator, Customer customer)
    {
        bool isValid = validator.Validate(customer);

        if (!isValid)
        {
            return new BadRequestObjectResult("Invalid customer data");
        }

        return new CreatedResult($"/customers/{customer.Id}", customer);
    }
}
```

## Zadanie

Masz działające testy i monolityczny `CustomerValidator`.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: kolejne reguły, złożone testy, jeden walidator w kontrolerze.

## Pytania do dyskusji

- Co dzieje się z klasą walidatora po dodaniu kolejnych reguł?
- Czy pojedynczy walidator nadal ma jedną odpowiedzialność?
- Jak można podzielić reguły na mniejsze elementy?
- Jak połączyć wiele niezależnych walidatorów?

## Ból

- Kolejne reguły = kolejne if-y
- Złożone testy
- Kontroler przyjmuje tylko jeden walidator

## Wniosek

Wraz ze wzrostem liczby reguł biznesowych rośnie złożoność walidatora.

Testy pozwalają bezpiecznie wydzielić reguły do osobnych klas i połączyć je we wzorcu **Composite**.
