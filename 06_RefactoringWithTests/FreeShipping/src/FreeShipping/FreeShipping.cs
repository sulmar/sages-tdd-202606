namespace FreeShipping;

public class FreeShipping
{
    public bool Qualifies(Order order)
    {
        if (order.Customer.HasActiveDeliveryPackage)
            return true;

        if ((order.TotalAmount >= 500 || order.Customer.IsFirstOrder)
            && order.Country == "PL"
            && !order.ContainsOversizedProducts)
        {
            return true;
        }

        return false;
    }
}
