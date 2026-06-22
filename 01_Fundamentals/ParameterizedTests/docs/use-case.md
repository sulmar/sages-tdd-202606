# Use Case: Walidacja hasła

## Opis

System rejestracji użytkowników wymaga sprawdzenia poprawności hasła przed utworzeniem konta.

Jeżeli hasło nie spełnia wymagań bezpieczeństwa, użytkownik powinien otrzymać odpowiedni komunikat o błędzie.

## Reguły biznesowe

- Hasło nie może być puste.
- Hasło musi mieć co najmniej 8 znaków.
- Hasło musi zawierać przynajmniej jedną cyfrę.
- Hasło musi zawierać przynajmniej jedną wielką literę.


## Przykłady

| Hasło | Oczekiwany rezultat |
|---------|-------------------|
| "" | EmptyPassword |
| "abc" | TooShortPassword |
| "abcdefgh" | PasswordWithoutDigit |
| "abcdefgh9" | PasswordWithoutUppercaseLetter |
| "Abcdefgh9" | Valid |


## Zadanie

Napisz testy dla metody:

```cs
PasswordValidationResult Validate(string password)
```

Przed rozpoczęciem implementacji:

1. Zaproponuj nazwy testów.
2. Wskaż sekcje Arrange, Act i Assert.
3. Zaimplementuj testy.
4. Oceń, czy wszystkie testy sprawdzają to samo zachowanie.

## Pytania do dyskusji

- Czy każdy przypadek powinien być osobnym testem?
- Kiedy warto użyć `[Fact]`?
- Kiedy warto użyć `[Theory]`?
- Jak uniknąć duplikacji testów?
- Czy poniższe testy mają podobną strukturę?

```cs
Validate_EmptyPassword_ReturnsInvalidResult()

Validate_TooShortPassword_ReturnsInvalidResult()

Validate_PasswordWithoutDigit_ReturnsInvalidResult()

Validate_PasswordWithoutUppercaseLetter_ReturnsInvalidResult()
```

- Czy można je uprościć przy użyciu parametryzacji danych?
