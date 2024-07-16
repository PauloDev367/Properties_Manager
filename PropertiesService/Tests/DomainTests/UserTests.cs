
using Domain.DomainExceptions;

namespace DomainTests;

public class UserTests
{
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
