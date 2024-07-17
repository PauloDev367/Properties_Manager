using Application.DTO.Request.Auth;
using Application.DTO.Request.Property;
using Application.User;
using Domain.Entities;
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
        public async Task ShouldCreateANewUser()
        {
            var newUserId = Guid.NewGuid();
            var fakeRepo = new Mock<IUserRepository>();
            var userService = new UserService(fakeRepo.Object);

            fakeRepo.Setup(x => x.CreateAsync(It.IsAny<Domain.Entities.User>()))
                .Returns(Task.FromResult(new Domain.Entities.User { Id = newUserId }));

            var dto = new CreateUserDto
            {
                Email = "email@email.com",
                Password = "HashSena@skdj2123",
                Name = "Name",
                Nickname = "N"
            };

            var created = await userService.CreateAsync(dto, "hash");
            Assert.AreEqual(created.User.Id, newUserId);
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
        [Test]
        public async Task ShouldReturnNullIfUserIsNotFound()
        {
            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetOneAsync(It.IsAny<Guid>()))
                .Returns(() => { return Task.FromResult((Domain.Entities.User)null); });

            var userService = new UserService(fakeRepo.Object);
            var user = await userService.GetOneAsync(Guid.NewGuid());

            Assert.IsNull(user.Id);
        }
        [Test]
        public async Task ShouldReturnUserWhenTheyAreFounded()
        {
            var userId = Guid.NewGuid();
            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetOneAsync(It.IsAny<Guid>()))
                .Returns(() => { return Task.FromResult(new Domain.Entities.User { Id = userId }); });

            var userService = new UserService(fakeRepo.Object);
            var user = await userService.GetOneAsync(Guid.NewGuid());

            Assert.AreEqual(userId, user.Id);
        }
        [Test]
        public async Task ShouldThrowAnErrorIfUserIsNotFoundOnDelete()
        {
            try
            {
                var fakeRepo = new Mock<IUserRepository>();
                fakeRepo.Setup(x => x.DeleteAsync(It.IsAny<Domain.Entities.User>()))
                    .Returns(() => { return Task.FromResult((Domain.Entities.User)null); });

                var userService = new UserService(fakeRepo.Object);

                await userService.DeleteAsync(Guid.NewGuid());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "User was not founded on database");
            }
        }
        [Test]
        public async Task ShouldDeleteUserIfTheyAreFound()
        {
            var userId = Guid.NewGuid();
            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetOneAsync(It.IsAny<Guid>()))
                .Returns(() => { return Task.FromResult(new Domain.Entities.User { Id = userId }); });
            fakeRepo.Setup(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.User>()))
                .Returns(() => { return Task.FromResult((object)null); });

            var userService = new UserService(fakeRepo.Object);

            await userService.DeleteAsync(Guid.NewGuid());

            fakeRepo.Verify(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.User>()), Times.Once);
        }
    }
}