namespace QuizGame.Exceptions;

public class WrongInputException : Exception
{
    public WrongInputException(string message)
        : base(message)
    {
    }
    public WrongInputException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
    public WrongInputException()
        : base("The input provided is incorrect or invalid.")
    {
    }
}
