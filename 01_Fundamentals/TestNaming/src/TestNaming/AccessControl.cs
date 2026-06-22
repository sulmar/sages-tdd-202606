namespace TestNaming;

public class Badge
{
    public bool IsActive { get; set; }
}

public class AccessControl
{
    public bool CanEnter(Badge badge)
    {
        if (badge.IsActive)
        {
            return true;
        }

        return false;
    }
}