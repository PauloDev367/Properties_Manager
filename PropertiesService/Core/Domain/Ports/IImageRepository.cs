namespace Application.Image.Ports;

public interface IImageRepository
{
    public Task<Domain.Entities.Image> CreateAsync(string path, Guid propertyId);
}
