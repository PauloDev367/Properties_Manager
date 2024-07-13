using Domain.Entities;
using Domain.Ports.DTO.Request;
using Domain.Ports.DTO.Response;

namespace Domain.Ports;

public interface IUserRepository
{
    public Task<ICreatedUserDto> CreateAsync(ICreateUserDto register, string passwordHash);
    public Task<List<User>> GetAllAsync();
    public Task<User> GetOneAsync();
}
