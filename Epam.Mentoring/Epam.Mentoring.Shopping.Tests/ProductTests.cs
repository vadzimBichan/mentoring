namespace Epam.Mentoring.Shopping.Tests;

[TestFixture]
public class ProductTests
{
    private readonly int _productId = 1;
    private readonly string _productName = "TestProduct";
    private readonly double _productPrice = 9.99;
    private readonly double _productQuantity = 100;
    private Product _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new Product(_productId, _productName, _productPrice, _productQuantity);
    }

    [Test]
    public void Ctor_ItIsCreatedWithDefaultValues()
    {
        var result = new Product(0, null, 0.0, 0.0);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Ctor_IdIsSetProperly()
    {
        Assert.That(_sut.Id, Is.EqualTo(_productId));
    }

    [Test]
    public void Ctor_NameIsSetProperly()
    {
        Assert.That(_sut.Quantity, Is.EqualTo(_productQuantity));
    }

    [Test]
    public void Ctor_PriceIsSetProperly()
    {
        Assert.That(_sut.Price, Is.EqualTo(_productPrice));
    }

    [Test]
    public void Ctor_QuantityIsSetProperly()
    {
        Assert.That(_sut.Price, Is.EqualTo(_productPrice));
    }

    [Test]
    public void ToString_ReturnsExpectedFormat()
    {
        const string expected = "Id: 1. Name: TestProduct. Price: 9.99. Quantity: 100";

        Assert.That(_sut.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void ToString_NameIsNull_DoesNotThrowException()
    {
        var product = new Product(0, null, 0.0, 0.0);

        Assert.DoesNotThrow(() => product.ToString());
    }
}