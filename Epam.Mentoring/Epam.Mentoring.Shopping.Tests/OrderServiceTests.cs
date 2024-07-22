using Moq;

namespace Epam.Mentoring.Shopping.Tests;

[TestFixture]
public class OrderServiceTests
{
    private Mock<IDiscountUtility> _discountUtilityMock;

    [SetUp]
    public void SetUp()
    {
        _discountUtilityMock = new Mock<IDiscountUtility>();
    }

    [Test]
    public void GetOrderPrice_ReturnsCorrectTotalPriceForUserWithDiscount()
    {
        // Arrange
        var user = new UserAccount("John", "Smith ", "1990/10/10");
        var product = new Product(1, "Test Product", 10, 5);
        user.ShoppingCart.AddProductToCart(product);
        var expectedOrderPrice = user.ShoppingCart.GetCartTotalPrice() - 3;

        _discountUtilityMock.Setup(x => x.CalculateDiscount(It.Is<UserAccount>(u => u.Name == "John"))).Returns(3);

        var sut = new OrderService(_discountUtilityMock.Object);

        // Act
        var actualOrderPrice = sut.GetOrderPrice(user);

        // Assert
        Assert.That(actualOrderPrice, Is.EqualTo(expectedOrderPrice));
        _discountUtilityMock.Verify(x => x.CalculateDiscount(It.Is<UserAccount>(u => u.Name == "John")), Times.Once);
        _discountUtilityMock.VerifyNoOtherCalls();
    }
}