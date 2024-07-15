using Domain.Entities;

namespace Domain.Ports;

public interface IPropertyRepository
{
    public Task<Property> CreateAsync(Property property);
    public Task<List<Property>> GetAllAsync(int perPage, int page, string orderBy, string order);
    public Task<Property?> GetOneAsync(Guid guid);
    public Task DeleteAsync(Property property);
}
