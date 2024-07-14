using Application.DTO.Request.Property;
using Application.DTO.Response.Property;
using Application.Image.Ports;
using Application.Property.Ports;
using Domain.Ports;

namespace Application.Property;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IImageRepository _imageRepository;
    public PropertyService(IPropertyRepository propertyRepository, IImageRepository imageRepository)
    {
        _propertyRepository = propertyRepository;
        _imageRepository = imageRepository;
    }

    public async Task<CreatedPropertyResponseDto> CreateAsync(CreatePropertyRequestDto request, List<string> pictures)
    {
        var property = new Domain.Entities.Property
        {
            Description = request.Description,
            MainPhoto = request.MainPhoto,
            Price = request.Price,
            Title = request.Title,
            TotalBath = request.TotalBath,
            TotalKitchen = request.TotalKitchen,
            TotalParkings = request.TotalParkings
        };

        var created = await _propertyRepository.CreateAsync(property);

        foreach (var p in pictures) {
            await _imageRepository.CreateAsync(p, property.Id);
        }

        return new CreatedPropertyResponseDto(created);
    }
}
