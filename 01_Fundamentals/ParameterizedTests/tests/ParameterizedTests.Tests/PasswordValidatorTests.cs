
public class PasswordValidatorTests
{
    private readonly PasswordValidator validator = new();

    [Theory]
    [InlineData("", PasswordValidationResult.EmptyPassword)]
    [InlineData("abc", PasswordValidationResult.TooShortPassword)]
    [InlineData("abcdefgh", PasswordValidationResult.PasswordWithoutDigit)]
    [InlineData("abcdefgh9", PasswordValidationResult.PasswordWithoutUppercaseLetter)]
    [InlineData("Abcdefgh9", PasswordValidationResult.Valid)]
    public void Validate_GivenPassword_ShouldReturnExpectedResult(string password, PasswordValidationResult expectedResult)
    {
        // Act
        var result = validator.Validate(password);
        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Validate_EmptyPassword_ShouldThrowException()
    {
        // Act
        Action act = () => validator.Validate(null);
        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }
}