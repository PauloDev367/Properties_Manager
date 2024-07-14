using Domain.Entities;

namespace Domain.Ports;

public interface IUserRepository
{
    public Task<User> CreateAsync(User register);
    public Task<List<User>> GetAllAsync(int perPage, int page, string orderBy, string order);
    public Task<User?> GetOneAsync(Guid id);
}
