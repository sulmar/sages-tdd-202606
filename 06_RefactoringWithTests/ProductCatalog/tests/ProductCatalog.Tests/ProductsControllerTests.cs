namespace ProductCatalog.Tests;

public class ProductsControllerTests
{
    private readonly ProductsController _productsController;

    public ProductsControllerTests()
    {
        var repository = new FakeProductRepository(new Product(1, "Product 1"));
        _productsController = new ProductsController(repository);
    }

    [Fact]
    public void Get_FirstCall_ShouldCacheHitEqualZero()
    {
        int productId = 1;

        ProductResponse? request = _productsController.Get(productId);

        Assert.Equal(0, request!.CacheHit);
        Assert.Equal(1, request.Id);
        Assert.Equal("Product 1", request.Name);
    }

    [Fact]
    public void Get_TwiceCalls_ShouldCacheHitEqualOne()
    {
        int productId = 1;
        _productsController.Get(productId);

        ProductResponse? request = _productsController.Get(productId);

        Assert.NotNull(request);
        Assert.Equal(1, request.CacheHit);
        Assert.Equal(1, request.Id);
        Assert.Equal("Product 1", request.Name);
    }

    [Fact]
    public void Get_ManyCalls_ShouldCacheHitAboveZero()
    {
        int productId = 1;
        _productsController.Get(productId);
        _productsController.Get(productId);
        _productsController.Get(productId);

        ProductResponse? request = _productsController.Get(productId);

        Assert.NotNull(request);
        Assert.Equal(3, request.CacheHit);
        Assert.Equal(1, request.Id);
        Assert.Equal("Product 1", request.Name);
    }

    [Fact]
    public void Get_NotFound_ShouldReturnsEmpty()
    {
        int productId = 999;

        _productsController.Get(productId);

        ProductResponse? request = _productsController.Get(productId);

        Assert.Null(request);
    }
}
