namespace QuizGame.Exceptions;

public class UsernameAlreadyExistsException : Exception
{
    public UsernameAlreadyExistsException(string message) : base(message)
    {
    }
    public UsernameAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
    public UsernameAlreadyExistsException() : base("Username already exists.")
    {
    }
}
