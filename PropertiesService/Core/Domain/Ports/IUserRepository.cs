using Domain.Entities;

namespace Domain.Ports;

public interface IUserRepository
{
    public Task<User> CreateAsync(User register);
    public Task<List<User>> GetAllAsync();
    public Task<User> GetOneAsync();
}
