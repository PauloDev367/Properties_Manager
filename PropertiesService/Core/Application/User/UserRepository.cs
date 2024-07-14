using DataEF;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Application.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
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

        var data = await query.AsNoTracking().ToListAsync();
        return data;
    }

    public Task<Domain.Entities.User> GetOneAsync()
    {
        throw new NotImplementedException();
    }
}
