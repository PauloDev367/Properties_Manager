using DataEF;
using Domain.Ports;

namespace Application.Property;

public class PropertyRepository : IPropertyRepository
{
    private readonly AppDbContext _appDbContext;

    public PropertyRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Domain.Entities.Property> CreateAsync(Domain.Entities.Property property)
    {
        await _appDbContext.Properties.AddAsync(property);
        await _appDbContext.SaveChangesAsync();

        return property;
    }

    public Task<List<Domain.Entities.Property>> GetAllAsync(int perPage, int page, string orderBy, string order)
    {
        throw new NotImplementedException();
    }
}
