namespace EmailProcessing;

public class EmailProcessor
{
    private static readonly HashSet<string> Whitelist =
    [
        "trusted@example.com",
        "partner@example.com"
    ];

    private readonly Dictionary<string, Customer> _customers = new()
    {
        ["1234567890"] = new Customer("1234567890", "Acme Corp")
    };

    private readonly List<Email> _createdQuotes = [];

    public IReadOnlyList<Email> CreatedQuotes => _createdQuotes;

    public void Process(Email email)
    {
        if (!IsWhitelisted(email.From))
        {
            return;
        }

        string? nip = ExtractNip(email.Body);

        if (nip is null)
        {
            return;
        }

        Customer? customer = LookupCustomer(nip);

        if (customer is null)
        {
            return;
        }

        CreateQuote(email);
    }

    private bool IsWhitelisted(string from) => Whitelist.Contains(from);

    private Customer? LookupCustomer(string nip) => _customers.GetValueOrDefault(nip);

    private void CreateQuote(Email email) => _createdQuotes.Add(email);

    private static string? ExtractNip(string body)
    {
        for (int i = 0; i <= body.Length - 10; i++)
        {
            if (body.Skip(i).Take(10).All(char.IsDigit))
            {
                return body.Substring(i, 10);
            }
        }

        return null;
    }
}
