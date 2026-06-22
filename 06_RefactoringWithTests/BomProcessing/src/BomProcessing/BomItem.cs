namespace BomProcessing;

public abstract class BomItem
{
    public string Name { get; }

    protected BomItem(string name)
    {
        Name = name;
    }
}

public class Profile : BomItem
{
    public decimal LengthInMeters { get; }

    public Profile(string name, decimal lengthInMeters)
        : base(name)
    {
        LengthInMeters = lengthInMeters;
    }
}

public class Column : BomItem
{
    public decimal HeightInMeters { get; }

    public Column(string name, decimal heightInMeters)
        : base(name)
    {
        HeightInMeters = heightInMeters;
    }
}

public class LedStrip : BomItem
{
    public decimal LengthInMeters { get; }

    public LedStrip(string name, decimal lengthInMeters)
        : base(name)
    {
        LengthInMeters = lengthInMeters;
    }
}
