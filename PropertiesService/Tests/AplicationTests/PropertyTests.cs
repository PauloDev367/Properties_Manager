using Application.DTO.Request.Property;
using Application.Image.Ports;
using Application.Property;
using Application.Property.Ports;
using Domain.Ports;
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
    public async Task ShouldCreateANewProperty()
    {
        var request = new CreatePropertyRequestDto
        {
            Description = "Test description",
            MainPhoto = "mainphoto.jpg",
            Price = new Domain.ValueObjects.Price { TypePropertyPayment = 1, Value = 2000.00 },
            Title = "Test Title",
            TotalBath = 2,
            TotalKitchen = 1,
            TotalParkings = 1
        };

        var pictures = new List<string> { "photo1.jpg", "photo2.jpg" };
        var createdGuid = Guid.NewGuid();
        var createdProperty = new Domain.Entities.Property { Id = createdGuid };

        var mockPropertyRepository = new Mock<IPropertyRepository>();
        var mockImageRepository = new Mock<IImageRepository>();

        mockPropertyRepository.Setup(repo => repo.CreateAsync(It.IsAny<Domain.Entities.Property>()))
                               .ReturnsAsync(createdProperty);

        var propertyService = new PropertyService(mockPropertyRepository.Object, mockImageRepository.Object);
        var result = await propertyService.CreateAsync(request, pictures);

        mockPropertyRepository.Verify(repo => repo.CreateAsync(It.IsAny<Domain.Entities.Property>()), Times.Once);
        Assert.AreEqual(createdProperty.Id, result.Id);
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
