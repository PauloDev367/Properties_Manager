namespace Domain.DomainExceptions;

public class InvalidUserException : Exception
{
    public InvalidUserException(string? message) : base(message)
    {
    }
}
