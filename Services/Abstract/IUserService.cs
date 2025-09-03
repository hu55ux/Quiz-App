using QuizGame.Entities;
namespace QuizGame.Services.Abstract;

public interface IUserService
{
    public User? Login(string username, string password);
    public void Register(string username, string password, DateTime birthdate);
    public User? GetUserById(int userId);
    public void UpdateUserData(QuizGameDBContext database, int userId);
    public bool DeleteUser(int userId);
}
