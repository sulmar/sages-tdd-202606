namespace EmailProcessing.Tests;

internal class TestHandler : EmailHandler
{
    public bool Called { get; private set; }

    protected override bool Process(EmailContext context)
    {
        Called = true;

        return true;
    }
}
