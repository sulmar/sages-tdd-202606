namespace EmailProcessing;

public record Email(
    string From,
    string Body,
    IReadOnlyList<string> Attachments);
