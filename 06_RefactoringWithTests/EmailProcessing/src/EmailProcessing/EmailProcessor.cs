namespace EmailProcessing;


public class EmailContext
{
    public Email Email { get; set; }
    public string? Nip { get; set; }
}


public abstract class EmailHandler 
{
    private EmailHandler? _next;

    public EmailHandler SetNext(EmailHandler next)
    {
        _next = next;

        return next;
    }

    public void Handle(EmailContext context)
    {
        if (!Process(context))
        {
            return;
        }

        if (_next != null)
            _next.Handle(context);       
    }

    protected abstract bool Process(EmailContext context);
}


public interface IWhitelistRepository
{
    bool Exists(string from);
}

public class InMemoryWhitelistRepository : IWhitelistRepository
{
    private static readonly HashSet<string> Whitelist =
    [
        "trusted@example.com",
        "partner@example.com"
    ];

    public bool Exists(string from)
    {
        return Whitelist.Contains(from);
    }
}


public class WhitelistHandler : EmailHandler
{
    private InMemoryWhitelistRepository repository;

    public WhitelistHandler(InMemoryWhitelistRepository repository)
    {
        this.repository = repository;
    }

    protected override bool Process(EmailContext context)
    {
        return IsWhitelisted(context.Email.From);
    }

    private bool IsWhitelisted(string from) => repository.Exists(from);
}

public class ExtractNipHandler : EmailHandler
{
    protected override bool Process(EmailContext context)
    {
        string? nip = ExtractNip(context.Email.Body);

        context.Nip = nip;

        return nip is not null;        
    }

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

public class LookupCustomerHandler : EmailHandler
{
    private readonly Dictionary<string, Customer> _customers = new()
    {
        ["1234567890"] = new Customer("1234567890", "Acme Corp")
    };

    protected override bool Process(EmailContext context)
    {
        Customer? customer = LookupCustomer(context.Nip!);

        return customer is not null;
    }

    private Customer? LookupCustomer(string nip) => _customers.GetValueOrDefault(nip);
}


public class CreateQuoteHandler : EmailHandler
{
    private readonly List<Email> _createdQuotes = [];

    public IReadOnlyList<Email> CreatedQuotes => _createdQuotes;

    protected override bool Process(EmailContext context)
    {
        CreateQuote(context.Email);

        return true;
    }

    private void CreateQuote(Email email) => _createdQuotes.Add(email);
}


public class EmailPipelineFactory
{
    private EmailHandler _pipeline;

    public EmailHandler Create()
    {
        var whitelist = new WhitelistHandler(new InMemoryWhitelistRepository());
        var extractNip = new ExtractNipHandler();
        var lookupCustomer = new LookupCustomerHandler();
        var createQuote = new CreateQuoteHandler();

        whitelist
            .SetNext(extractNip)
            .SetNext(lookupCustomer)
            .SetNext(createQuote);

        _pipeline = whitelist;

        return _pipeline;
    }
}

public class EmailProcessor
{
    private readonly EmailHandler _pipeline;

    public EmailProcessor(EmailPipelineFactory factory)
    {       
        _pipeline = factory.Create();
    }

    public void Process(Email email)
    {
        _pipeline.Handle(new EmailContext { Email = email });             
    }  
}
