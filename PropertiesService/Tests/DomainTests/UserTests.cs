
using Domain.DomainExceptions;

namespace DomainTests;

public class UserTests
{
    [TestCase("12A3")]
    [TestCase("123A4")]
    [TestCase("123A56")]
    [TestCase("kdJals")]
    public void ShouldNotCreateANewUserWithAPasswordLessThanEigth(string password)
    {
        var error = Assert.Throws<InvalidPasswordException>(() =>
        {
            var user = new Domain.Entities.User
            {
                Email = "email@email.com",
                Password = password,
                Name = "Name",
                Nickname = "N"
            };
        });

        Assert.AreEqual("Password can't be less than 8 chars", error.Message);
    }
    [TestCase("12345678")]
    [TestCase("123aa4sadas")]
    [TestCase("1235asdqw16")]
    [TestCase("aklsdjlkewasd")]
    public void ShouldNotCreateANewUserWithAPasswordWithoutAnUpperCharacter(string password)
    {
        var error = Assert.Throws<InvalidPasswordException>(() =>
        {
            var user = new Domain.Entities.User
            {
                Email = "email@email.com",
                Password = password,
                Name = "Name",
                Nickname = "N"
            };
        });

        Assert.AreEqual("Password need to have one upper character", error.Message);
    }
    [Test]
    public void ShouldNotCreateANewUserWithANameLessThanThreeCharacter()
    {
        var error = Assert.Throws<InvalidUserException>(() =>
        {
            var user = new Domain.Entities.User
            {
                Email = "email@email.com",
                Password = "Senha123456",
                Name = "In",
                Nickname = "N"
            };
        });
        Assert.AreEqual("The user name need to have minimum 3 characteres", error.Message);
    }

}
