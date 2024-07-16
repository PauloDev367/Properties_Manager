using Application.ApplicationExceptions;
using DataEF;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Dynamic.Core;

namespace Application.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMemoryCache _cache;
    private readonly string _userGetCacheBaseKey = "userGetCacheBaseKey";
    public UserRepository(AppDbContext appDbContext, IMemoryCache cache)
    {
        _appDbContext = appDbContext;
        _cache = cache;
    }

    public async Task<Domain.Entities.User> CreateAsync(Domain.Entities.User register)
    {
        var user = new Domain.Entities.User
        {
            Email = register.Email,
            Name = register.Name,
            Nickname = register.Nickname,
            Password = register.Password
        };

        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();

        return user;
    }

    public async Task<List<Domain.Entities.User>> GetAllAsync(int perPage, int page, string orderBy, string order)
    {
        var cacheKey = $"{_userGetCacheBaseKey}{perPage}{page}";
        if (!_cache.TryGetValue(cacheKey, out List<Domain.Entities.User> data))
        {
            IQueryable<Domain.Entities.User> query = _appDbContext.Users;
            var totalCount = await query.CountAsync();
            int skipAmount = page * perPage;
            query = query
                .OrderBy(orderBy + " " + order)
                .Skip(skipAmount)
                .Take(perPage);

            var totalPages = (int)Math.Ceiling((double)totalCount / perPage);
            var currentPage = page + 1;
            var nextPage = currentPage < totalPages ? currentPage + 1 : 1;
            var prevPage = currentPage > 1 ? currentPage - 1 : 1;

            data = await query.AsNoTracking().ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(45))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                .SetPriority(CacheItemPriority.Normal);
            _cache.Set(cacheKey, data, cacheEntryOptions);
        }

        return data;
    }

    public Task<Domain.Entities.User?> GetOneAsync(Guid id)
    {
        var user = _appDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }
    public async Task DeleteAsync(Domain.Entities.User user)
    {        
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();
    }
}
