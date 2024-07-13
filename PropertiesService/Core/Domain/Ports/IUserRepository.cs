using Domain.Entities;

namespace Domain.Ports;

public interface IUserRepository
{
    public Task<User> CreateAsync();
    public Task<List<User>> GetAllAsync();
    public Task<User> GetOneAsync();
}
