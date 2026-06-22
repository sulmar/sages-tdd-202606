namespace ShortUrlGenerator;

public class UrlShortener
{
    private const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";

    public string Generate(int length = 6)
    {
        var random = new Random();
        return new string(Enumerable.Range(0, length)
            .Select(_ => AllowedCharacters[random.Next(AllowedCharacters.Length)])
            .ToArray());
    }
}
