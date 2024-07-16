using Application.DTO.Request.Auth;
using Application.User;
using Domain.DomainExceptions;
using Domain.Ports;
using Moq;

namespace AplicationTests
{
    public class UserServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ShouldNotCreateANewUserWithWrongName()
        {
            try
            {
                var fakeRepo = new Mock<IUserRepository>();
                var userService = new UserService(fakeRepo.Object);

                fakeRepo.Setup(x => x.CreateAsync(It.IsAny<Domain.Entities.User>()))
                    .Returns(Task.FromResult(new Domain.Entities.User { }));

                var dto = new CreateUserDto
                {
                    Email = "email@email.com",
                    Password = "HashSena@skdj2123",
                    Name = "Na",
                    Nickname = "N"
                };

                await userService.CreateAsync(dto, "hash");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The user name need to have minimum 3 characteres", ex.Message);
            }
        }
    }
}