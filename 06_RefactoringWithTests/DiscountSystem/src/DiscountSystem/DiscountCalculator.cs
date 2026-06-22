namespace DiscountSystem;

public class DiscountCalculator
{
    public decimal CalculateDiscount(Order order)
    {
        if (order.DiscountType == DiscountType.Percentage)
            return order.TotalAmount * order.PercentageRate;

        if (order.DiscountType == DiscountType.FixedAmount)
            return Math.Min(order.FixedDiscountAmount, order.TotalAmount);

        if (order.DiscountType == DiscountType.HappyHours)
        {
            TimeSpan time = order.OrderTime.TimeOfDay;

            if (time >= TimeSpan.FromHours(14) && time < TimeSpan.FromHours(16))
                return order.TotalAmount * 0.15m;

            return 0;
        }

        if (order.DiscountType == DiscountType.Weekend)
        {
            if (order.OrderTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                return order.TotalAmount * 0.10m;

            return 0;
        }

        return 0;
    }
}
