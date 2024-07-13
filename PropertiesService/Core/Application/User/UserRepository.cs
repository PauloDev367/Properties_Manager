using DataEF;
using Domain.Ports;


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

    public Task<List<Domain.Entities.User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.User> GetOneAsync()
    {
        throw new NotImplementedException();
    }
}
