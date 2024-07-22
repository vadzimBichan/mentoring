namespace Epam.Mentoring.Shopping.Tests;

[TestFixture]
public class ShoppingCartTests
{
    private ShoppingCart _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new ShoppingCart();
    }

    [Test]
    public void AddProductToCart_AddsProductCorrectly()
    {
        var product = new Product(1, "Test Product", 10.00, 2);

        _sut.AddProductToCart(product);

        Assert.That(_sut.Products.Count, Is.EqualTo(1));
        Assert.That(_sut.Products.Contains(product), Is.True);
    }

    [Test]
    public void AddProductToCart_IncreasesQuantityIfProductExists()
    {
        var product = new Product(1, "Test Product", 10.00, 2);

        _sut.AddProductToCart(product);
        _sut.AddProductToCart(product);

        Assert.That(_sut.GetProductById(product.Id).Quantity, Is.EqualTo(4));
    }

    [Test]
    public void RemoveProductFromCart_RemovesProductCorrectly()
    {
        var product = new Product(1, "Test Product", 10.00, 2);

        _sut.AddProductToCart(product);
        _sut.RemoveProductFromCart(product);

        Assert.That(_sut.Products.Count, Is.EqualTo(0));
        Assert.That(_sut.Products.Contains(product), Is.False);
    }

    [Test]
    public void RemoveProductFromCart_ThrowsExceptionWhenProductNotFound()
    {
        var product = new Product(1, "Test Product", 10.00, 2);

        Assert.Throws<ProductNotFoundException>(() => _sut.RemoveProductFromCart(product));
    }

    [Test]
    public void GetCartTotalPrice_ReturnsCorrectTotalPrice()
    {
        var product1 = new Product(1, "Test Product 1", 10.00, 2);
        var product2 = new Product(2, "Test Product 2", 20.00, 3);

        _sut.AddProductToCart(product1);
        _sut.AddProductToCart(product2);

        var expectedTotalPrice = product1.Price * product1.Quantity + product2.Price * product2.Quantity;

        Assert.That(_sut.GetCartTotalPrice(), Is.EqualTo(expectedTotalPrice));
    }
}