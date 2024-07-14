namespace Application.DTO.Response.User;

public class BasicUserInfoResponseDto
{
    public Guid? Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Nickname { get; set; }
    public DateTime? CreatedAt { get; set; }
    public BasicUserInfoResponseDto()
    {
        
    }

    public BasicUserInfoResponseDto(Domain.Entities.User user)
    {
        Id = user.Id;
        Email = user.Email;
        Name = user.Name;
        Nickname = user.Nickname;
        CreatedAt = user.CreatedAt;
    }
}
