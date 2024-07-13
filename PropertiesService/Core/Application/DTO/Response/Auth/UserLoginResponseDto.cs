namespace Application.DTO.Response.Auth;

public class UserLoginResponseDto 
{
    public string Token { get; set; }
    public List<string> Errors { get; set; }
    public DateTime ExpirationTime { get; set; }
    public UserLoginResponseDto() => Errors = new List<string>();
    public void AddError(string error) => Errors.Add(error);

    public void SetError(List<string> error) => Errors = error;
}
