namespace Application.DTO.Response.User;

public class BasicUserInfoResponseDto
{
    public Guid? Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Nickname { get; set; }
    public DateTime? CreatedAt { get; set; }
}
