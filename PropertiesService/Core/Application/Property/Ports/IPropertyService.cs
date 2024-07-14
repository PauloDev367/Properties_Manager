using Application.DTO.Request.Property;
using Application.DTO.Response.Property;

namespace Application.Property.Ports;

public interface IPropertyService
{
    public Task<CreatedPropertyResponseDto> CreateAsync(CreatePropertyRequestDto request, List<string> pictures);
}
