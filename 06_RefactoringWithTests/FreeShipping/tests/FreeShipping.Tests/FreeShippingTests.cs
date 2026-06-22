namespace FreeShipping.Tests;

public class FreeShippingTests
{
    private readonly global::FreeShipping.FreeShipping _freeShipping = new();

    [Fact]
    public void Qualifies_CustomerWithActiveDeliveryPackage_ReturnsTrue()
    {
        var customer = new Customer(HasActiveDeliveryPackage: true, IsFirstOrder: false);
        var order = new Order(customer, TotalAmount: 100, Country: "DE", ContainsOversizedProducts: true);

        bool result = _freeShipping.Qualifies(order);

        Assert.True(result);
    }

    [Fact]
    public void Qualifies_OrderTotal500OrMoreInPolandWithoutOversizedProducts_ReturnsTrue()
    {
        var customer = new Customer(HasActiveDeliveryPackage: false, IsFirstOrder: false);
        var order = new Order(customer, TotalAmount: 500, Country: "PL", ContainsOversizedProducts: false);

        bool result = _freeShipping.Qualifies(order);

        Assert.True(result);
    }

    [Fact]
    public void Qualifies_FirstOrderInPolandWithoutOversizedProducts_ReturnsTrue()
    {
        var customer = new Customer(HasActiveDeliveryPackage: false, IsFirstOrder: true);
        var order = new Order(customer, TotalAmount: 100, Country: "PL", ContainsOversizedProducts: false);

        bool result = _freeShipping.Qualifies(order);

        Assert.True(result);
    }

    [Fact]
    public void Qualifies_OrderBelow500AndNotFirstOrder_ReturnsFalse()
    {
        var customer = new Customer(HasActiveDeliveryPackage: false, IsFirstOrder: false);
        var order = new Order(customer, TotalAmount: 499, Country: "PL", ContainsOversizedProducts: false);

        bool result = _freeShipping.Qualifies(order);

        Assert.False(result);
    }

    [Fact]
    public void Qualifies_OrderOutsidePoland_ReturnsFalse()
    {
        var customer = new Customer(HasActiveDeliveryPackage: false, IsFirstOrder: true);
        var order = new Order(customer, TotalAmount: 500, Country: "DE", ContainsOversizedProducts: false);

        bool result = _freeShipping.Qualifies(order);

        Assert.False(result);
    }

    [Fact]
    public void Qualifies_OrderWithOversizedProducts_ReturnsFalse()
    {
        var customer = new Customer(HasActiveDeliveryPackage: false, IsFirstOrder: true);
        var order = new Order(customer, TotalAmount: 500, Country: "PL", ContainsOversizedProducts: true);

        bool result = _freeShipping.Qualifies(order);

        Assert.False(result);
    }
}
