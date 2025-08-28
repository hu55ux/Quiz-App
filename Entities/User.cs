namespace QuizGame.Entities;

public class User
{

    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime Birthdate { get; set; }
    public User()
    { }
    public void Display()
    {
        Console.WriteLine($"Username: {Username}");
        Console.WriteLine($"Birthdate: {Birthdate.ToShortDateString()}");
    }
}
