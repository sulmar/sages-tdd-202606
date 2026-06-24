using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class PasswordValidator
{
    public PasswordValidationResult Validate(string password) => password switch
    {
        null => throw new ArgumentNullException(":("),
        "" => PasswordValidationResult.EmptyPassword,
        { Length: < 8 } => PasswordValidationResult.TooShortPassword,
        _ when !password.Any(char.IsDigit) => PasswordValidationResult.PasswordWithoutDigit,
        _ when !password.Any(char.IsUpper) => PasswordValidationResult.PasswordWithoutUppercaseLetter,
        _ => PasswordValidationResult.Valid,
    };
}
public enum PasswordValidationResult
{
    [Display(Name = "Password")]
    EmptyPassword,
    [Display(Name = "Too Short Password")]
    TooShortPassword,
    [Display(Name = "Password Without Digit")]
    PasswordWithoutDigit,
    [Display(Name = "Password Without Uppercase Letter")]
    PasswordWithoutUppercaseLetter,
    [Display(Name = "Valid Password")]
    Valid
}


// Wzorzec projektowy: Adapter
public class ValidationResultConverter
{
   public static string Convert(PasswordValidationResult result) => result switch
   {
       PasswordValidationResult.EmptyPassword => ConstInvalidResultMsg.EmptyPassword,
       PasswordValidationResult.TooShortPassword => ConstInvalidResultMsg.TooShortPassword,
       PasswordValidationResult.PasswordWithoutDigit => ConstInvalidResultMsg.PasswordWithoutDigit,
       PasswordValidationResult.PasswordWithoutUppercaseLetter => ConstInvalidResultMsg.PasswordWithoutUppercaseLetter,
       PasswordValidationResult.Valid => "Hasło jest poprawne.",
       _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
   };
}

public static class ConstInvalidResultMsg
{
    public static string EmptyPassword = "Hasło nie może być puste.";
    public static string TooShortPassword = "Hasło musi mieć co najmniej 8 znaków";
    public static string PasswordWithoutDigit = "Hasło musi zawierać przynajmniej jedną cyfrę.";
    public static string PasswordWithoutUppercaseLetter = "Hasło musi zawierać przynajmniej jedną wielką literę.";
}