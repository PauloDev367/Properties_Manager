using Application.DTO.Request.Property;
using Application.DTO.Request.User;
using Application.DTO.Response.Property;

namespace Application.Property.Ports;

public interface IPropertyService
{
    public Task<CreatedPropertyResponseDto> CreateAsync(CreatePropertyRequestDto request, List<string> pictures);
    public Task<PropertyPaginationResponseDto> GetAllAsync(GetPropertyParamsRequestDto request);
    public Task RemoveAsync(Guid id);
}
