
using Application.DTO.Response.User;

namespace Application.DTO.Response.Auth;

public class CreatedUserDto
{
    public BasicUserInfoResponseDto? User { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public CreatedUserDto FromUser(Domain.Entities.User user)
    {
        return new CreatedUserDto
        {
            User = new BasicUserInfoResponseDto
            {
                Email = user.Email,
                Name = user.Name,
                Nickname = user.Nickname,
                Id = user.Id,
                CreatedAt = user.CreatedAt,
            }
        };
    }
    public void AddError(string error) => Errors.Add(error);

    public void SetError(List<string> error) => Errors = error;
}
