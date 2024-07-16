using Domain.DomainExceptions;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    private string _password { get; set; }
    public string Password
    {
        get { return _password; }
        set
        {

            if (value.Length < 8)
            {
                throw new InvalidPasswordException("Password can't be less than 8 chars");
            }
            else if (!value.Any(char.IsUpper))
            {
                throw new InvalidPasswordException("Password need to have one upper character");
            }
            else
            {
                _password = value;
            }

        }
    }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
