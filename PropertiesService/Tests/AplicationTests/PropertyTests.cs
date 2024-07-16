using Application.Image.Ports;
using Application.Property;
using Domain.Ports;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;

namespace AplicationTests;

public class PropertyTests
{
    private IImageRepository _imageRepository;

    [SetUp]
    public void Setup()
    {
        var faker = new Mock<IImageRepository>();
        _imageRepository = faker.Object;
    }

    [Test]
    public async Task ShouldThrowExceptionIfPropertyIsNotFound()
    {
        try
        {
            var faker = new Mock<IPropertyRepository>();
            faker.Setup(x => x.GetOneAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult((Domain.Entities.Property)null));

            var propertyService = new PropertyService(faker.Object, _imageRepository);
            await propertyService.GetOneAsync(Guid.NewGuid());
        }
        catch (Exception ex)
        {
            Assert.AreEqual(ex.Message, "Property was not founded");
        }
    }
}
