namespace BomProcessing;

public class BomProcessor
{
    public decimal CalculateCost(IEnumerable<BomItem> items)
    {
        decimal total = 0;

        foreach (var item in items)
        {
            if (item is Profile profile)
            {
                total += profile.LengthInMeters * 100;
            }
            else if (item is Column column)
            {
                total += column.HeightInMeters * 150;
            }
            else if (item is LedStrip ledStrip)
            {
                total += ledStrip.LengthInMeters * 40;
            }
        }

        return total;
    }

    public decimal CalculateWeight(IEnumerable<BomItem> items)
    {
        decimal total = 0;

        foreach (var item in items)
        {
            if (item is Profile profile)
            {
                total += profile.LengthInMeters * 2.5m;
            }
            else if (item is Column column)
            {
                total += column.HeightInMeters * 4.0m;
            }
            else if (item is LedStrip ledStrip)
            {
                total += ledStrip.LengthInMeters * 0.2m;
            }
        }

        return total;
    }
}
