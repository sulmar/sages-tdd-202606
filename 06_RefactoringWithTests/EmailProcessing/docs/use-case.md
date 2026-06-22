# Use Case: Przetwarzanie wiadomości e-mail

## Opis

System przetwarza wiadomości e-mail od klientów i tworzy wyceny.

W kolejnych iteracjach system będzie rozszerzany o nowe reguły kwalifikacji wiadomości.

## Reguły biznesowe

### Iteracja 1

Przetwarzaj wiadomości tylko od nadawców z białej listy.

### Iteracja 2

Wiadomość musi zawierać NIP.

### Iteracja 3

Wiadomość musi posiadać załącznik.

### Iteracja 4

Klient musi istnieć w bazie.

## Przykłady

### Iteracja 1

| Nadawca | Oczekiwany wynik |
|---------|------------------|
| `unknown@example.com` | Wiadomość pominięta |
| `trusted@example.com` | Wycena utworzona |

### Iteracja 2

| Nadawca | Treść | Oczekiwany wynik |
|---------|-------|------------------|
| `trusted@example.com` | „Proszę o wycenę" | Wiadomość pominięta |
| `trusted@example.com` | „NIP: 1234567890" | Wycena utworzona |

### Iteracja 3

| Nadawca | Treść | Załączniki | Oczekiwany wynik |
|---------|-------|------------|------------------|
| `trusted@example.com` | „NIP: 1234567890" | Brak | Wiadomość pominięta |
| `trusted@example.com` | „NIP: 1234567890" | `spec.pdf` | Wycena utworzona |

### Iteracja 4

| Nadawca | Treść | Załączniki | Klient w bazie | Oczekiwany wynik |
|---------|-------|------------|----------------|------------------|
| `trusted@example.com` | „NIP: 9876543210" | `spec.pdf` | Nie | Wiadomość pominięta |
| `trusted@example.com` | „NIP: 1234567890" | `spec.pdf` | Tak | Wycena utworzona, załączniki zapisane |

## Implementacja

```cs
public record Email(
    string From,
    string Body,
    IReadOnlyList<string> Attachments);
```

```cs
public record Customer(
    string Nip,
    string Name);
```

```cs
public class EmailProcessor
{
    public void Process(Email email)
    {
        if (!IsWhitelisted(email.From))
        {
            return;
        }

        if (!ContainsNip(email.Body))
        {
            return;
        }

        if (!HasAttachments(email))
        {
            return;
        }

        var customer = LookupCustomer(email.Body);

        if (customer == null)
        {
            return;
        }

        SaveAttachments(email, customer);

        CreateQuote(email);
    }
}
```

## Zadanie

Masz działające testy i monolityczną metodę `Process`.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: kolejne reguły, rosnąca liczba warunków, jedna metoda z wieloma krokami procesu.

## Pytania do dyskusji

- Co dzieje się z metodą po dodaniu kolejnej reguły?
- Czy wszystkie kroki procesu powinny żyć w jednej klasie?
- Jak testować poszczególne kroki przetwarzania w izolacji?
- Jak wydzielić kroki do osobnych handlerów?

## Ból

- Kolejne reguły = kolejne if-y
- Rosnąca złożoność jednej metody
- Trudne rozszerzanie o nowe kroki procesu

## Wniosek

Wraz ze wzrostem liczby kroków procesu rośnie złożoność metody przetwarzającej wiadomości.

Testy pozwalają bezpiecznie wydzielić kroki do osobnych handlerów i połączyć je we wzorcu **Chain of Responsibility**.
