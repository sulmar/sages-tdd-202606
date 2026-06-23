namespace ArrangeActAssert.Tests;


public class ShoppingCartTests
{
    private readonly ShoppingCart shoppingCart = new ShoppingCart();

    [Fact]
    public void Constructor_NewCart_SetsCreationDate()
    {        
        // Act
        var newShoppingCart = new ShoppingCart();

        // Assert
        Assert.NotEqual(default, newShoppingCart.CreatedAt);
    }

   
    [Fact]
    public void Construct_NewCart_ReturnsZeroTotal()
    {
        // Act
        var newShoppingCart = new ShoppingCart();

        // Assert
        Assert.Equal(0.0m, newShoppingCart.CalculateTotal());
    }


    [Fact]
    public void CalculateTotal_SingleProduct_ReturnsProductPrice()
    {
        // Arrange        
        shoppingCart.AddProduct("a", 100.0m);

        // Act
        var result = shoppingCart.CalculateTotal();

        // Assert
        Assert.Equal(100.0m, result);
    }

    [Fact]
    public void CalculateTotal_MultipleProducts_ReturnsSum()
    {                
        shoppingCart.AddProduct("a", 100.0m);
        shoppingCart.AddProduct("b", 200.0m);
        
        var result = shoppingCart.CalculateTotal();

        Assert.Equal(300.0m, result);
    }

    [Fact]
    public void RemoveProduct_ExistingProduct_DecreasesTotal()
    {
        // Arrange        
        shoppingCart.AddProduct("a", 100.0m);
        shoppingCart.AddProduct("b", 200.0m);

        // Act
        shoppingCart.RemoveProduct("a");

        // Assert
        Assert.Equal(200.0m, shoppingCart.CalculateTotal());

    }

    [Fact]
    public void RemoveProduct_LastRemainingProduct_ReturnsZeroTotal()
    {
        // Arrange        
        shoppingCart.AddProduct("a", 100.0m);        

        // Act
        shoppingCart.RemoveProduct("a");

        // Assert
        Assert.Equal(0.0m, shoppingCart.CalculateTotal());
    }
    
}