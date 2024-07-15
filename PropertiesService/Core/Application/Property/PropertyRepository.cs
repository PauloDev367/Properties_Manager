using DataEF;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Dynamic.Core;

namespace Application.Property;

public class PropertyRepository : IPropertyRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMemoryCache _cache;
    private readonly string _propertyGetCacheBaseKey = "propertyGetCacheBaseKey";

    public PropertyRepository(AppDbContext appDbContext, IMemoryCache cache)
    {
        _appDbContext = appDbContext;
        _cache = cache;
    }

    public async Task<Domain.Entities.Property> CreateAsync(Domain.Entities.Property property)
    {
        await _appDbContext.Properties.AddAsync(property);
        await _appDbContext.SaveChangesAsync();

        return property;
    }

    public async Task<List<Domain.Entities.Property>> GetAllAsync(int perPage, int page, string orderBy, string order)
    {

        IQueryable<Domain.Entities.Property> query = _appDbContext.Properties;
        var totalCount = await query.CountAsync();
        int skipAmount = page * perPage;
        query = query
            .OrderBy(orderBy + " " + order)
            .Skip(skipAmount)
            .Take(perPage)
            .Include(x => x.Images);

        var totalPages = (int)Math.Ceiling((double)totalCount / perPage);
        var currentPage = page + 1;
        var nextPage = currentPage < totalPages ? currentPage + 1 : 1;
        var prevPage = currentPage > 1 ? currentPage - 1 : 1;

        var data = await query.AsNoTracking().ToListAsync();

        return data;
    }
    public async Task<Domain.Entities.Property?> GetOneAsync(Guid guid)
    {
        return await _appDbContext.Properties.FirstOrDefaultAsync(x => x.Id == guid);
    }
    public async Task DeleteAsync(Domain.Entities.Property property)
    {
        _appDbContext.Properties.Remove(property);
        await _appDbContext.SaveChangesAsync();
    }
}
