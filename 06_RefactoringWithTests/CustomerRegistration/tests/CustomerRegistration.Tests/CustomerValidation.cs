namespace CustomerRegistration.Tests;

internal static class CustomerValidation
{
    public static CompositeValidator Create() => new(
        new EmailValidator(),
        new AdultAgeValidator(),
        new AcceptedTermsValidator(),
        new DomesticResidentValidator());
}
