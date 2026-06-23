namespace TestNaming;

public class Badge
{
    public bool IsActive { get; set; }
}

public class AccessControl
{
    public bool CanEnter(Badge badge) => badge != null && badge.IsActive;
}