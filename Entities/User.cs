namespace QuizGame.Entities;

public class User
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }

    public void Display()
    {
        Console.WriteLine($"User ID: {Id}");
        Console.WriteLine($"Username: {Username}");
        Console.WriteLine($"Birthdate: {Birthdate.ToShortDateString()}");
    }
}
