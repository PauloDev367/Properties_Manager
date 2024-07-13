using Application.DTO.Request.Auth;
using Application.DTO.Result.Auth;
using DataEF;
using Domain.Ports;
using Domain.Ports.DTO.Request;
using Domain.Ports.DTO.Result;

namespace Application.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ICreatedUserDto> CreateAsync(ICreateUserDto register, string passwordHash)
    {
        var user = new Domain.Entities.User
        {
            Email = register.Email,
            Name = register.Name,
            Nickname = register.Nickname,
            Password = passwordHash
        };

        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();

        return new CreatedUserDto().FromUser(user);
    }

    public Task<List<Domain.Entities.User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.User> GetOneAsync()
    {
        throw new NotImplementedException();
    }
}
