namespace Application.DTO.Response.User;

public class UserPaginationResponseDto
{
    public int PerPage { get; set; }
    public int Page { get; set; }
    public int TotalItems { get; set; }
    public List<BasicUserInfoResponseDto> Users { get; set; }
    
}
