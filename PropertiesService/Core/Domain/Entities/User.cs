using Domain.DomainExceptions;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    private string _name { get; set; }
    public string Name { get { return _name; } set
        {
            if(value.Length < 3)
            {
                throw new InvalidUserException("The user name need to have minimum 3 characteres");
            }
            else
            {
                _name = value;
            }
        }
}

    public string Nickname { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
