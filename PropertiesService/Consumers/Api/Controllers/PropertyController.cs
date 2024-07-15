using Api.Services;
using Api.ViewModels;
using Application.DTO.Request.Property;
using Application.DTO.Request.User;
using Application.Property.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/properties")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;
    private readonly SavePropertyFilesService _savePropertyFilesService;
    public PropertyController(IPropertyService propertyService, SavePropertyFilesService savePropertyFilesService)
    {
        _propertyService = propertyService;
        _savePropertyFilesService = savePropertyFilesService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreatePropertyVM vm)
    {
        var mainPhoto = await _savePropertyFilesService.SaveAsync(vm.MainPhoto);
        var photos = new List<string>();
        foreach (var item in vm.Files)
        {
            var path = await _savePropertyFilesService.SaveAsync(item);
            photos.Add(path);
        }

        var data = new CreatePropertyRequestDto
        {
            Description = vm.Description,
            MainPhoto = mainPhoto,
            Price = vm.Price,
            Title = vm.Title,
            TotalBath = vm.TotalBath,
            TotalKitchen = vm.TotalKitchen,
            TotalParkings = vm.TotalParkings,
        };

        var created = await _propertyService.CreateAsync(data, photos);
        var uri = "api/v1/properties/" + created.Id;
        return Created(uri, created);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetPropertyParamsRequestDto request)
    {
        var data = await _propertyService.GetAllAsync(request);
        return Ok(data);
    }
    [HttpDelete("id:guid")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _propertyService.RemoveAsync(id);
        return NoContent();
    }
    [HttpGet("id:guid")]
    public async Task<IActionResult> GetOneAsync(Guid id)
    {
        var property = await _propertyService.GetOneAsync(id);
        return Ok(property);
    }
}
