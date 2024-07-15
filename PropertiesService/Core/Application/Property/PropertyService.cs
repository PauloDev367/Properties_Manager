using Application.ApplicationExceptions;
using Application.DTO.Request.Property;
using Application.DTO.Request.User;
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

        foreach (var p in pictures)
        {
            await _imageRepository.CreateAsync(p, property.Id);
        }

        return new CreatedPropertyResponseDto(created);
    }
    public async Task<PropertyPaginationResponseDto> GetAllAsync(GetPropertyParamsRequestDto request)
    {
        string[] orderParams = !string.IsNullOrEmpty(request.OrderBy) ? request.OrderBy.ToString().Split(",") : "id,desc".Split(",");
        var orderBy = orderParams[0];
        var order = orderParams[1];

        var data = await _propertyRepository.GetAllAsync(request.PerPage, request.Page, orderBy, order);
        var properties = data.Select(p => new PropertyListResponse(p)).ToList();
        var response = new PropertyPaginationResponseDto
        {
            Page = request.Page,
            PerPage = request.PerPage,
            Properties = properties,
            TotalItems = properties.Count
        };
        return response;
    }
    public async Task RemoveAsync(Guid id)
    {
        var property = await _propertyRepository.GetOneAsync(id);
        if (property == null) throw new PropertyNotFoundException("Property was not founded");

        _propertyRepository.DeleteAsync(property);
    }
    public async Task<OnePropertyResponseDto> GetOneAsync(Guid id)
    {
        var property = await _propertyRepository.GetOneAsync(id);
        if (property == null) throw new PropertyNotFoundException("Property was not founded");

        return new OnePropertyResponseDto(property);
    }
}
