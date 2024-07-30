namespace Epam.Mentoring.Shopping.Tests;

[TestFixture]
public class UserAccountTests
{
    [Test]
    public void Constructor_ShouldCorrectlyAssignProperties_AndInitializeShoppingCart()
    {
        // Arrange
        const string expectedName = "TestName";
        const string expectedSurname = "TestSurname";
        const string expectedDateOfBirth = "1990-01-01";

        // Act
        var userAccount = new UserAccount(expectedName, expectedSurname, expectedDateOfBirth);

        // Assert
        Assert.That(userAccount.Name, Is.EqualTo(expectedName));
        Assert.That(userAccount.Surname, Is.EqualTo(expectedSurname));
        Assert.That(userAccount.DateOfBirth, Is.EqualTo(expectedDateOfBirth));
        Assert.That(userAccount.ShoppingCart, Is.Not.Null);
    }
}