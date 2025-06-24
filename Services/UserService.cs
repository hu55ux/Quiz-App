using QuizGame.Entities;
using QuizGame.Exceptions;
using QuizGame.Services.Abstract;

namespace QuizGame.Services;

public class UserService : BaseService, IUserService
{
    public UserService(Database.Database database) : base(database)
    {
    }

    public User? GetUserById(string userId)
    {
        var User = _database.Users?.FirstOrDefault(u => u.Id == userId);
        if (User == null)
        {
            throw new UserNotFoundException($"User not found with ID: {userId}");
        }
        return User;
    }

    public User? Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Username and password cannot be empty.");
        }
        if (_database.Users == null)
        {
            throw new UserNotFoundException("No users found in the database.");
        }
        if (_database.Users.Any(u => u.Username == username && u.Password == password))
        {
            return _database.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        return null;
    }

    public void Register(string username, string password, DateTime birthdate)
    {
        if (_database.Users.Any(u => u.Username == username))
        {
            throw new UsernameAlreadyExistsException("Username already exists.");
        }
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Username and password cannot be empty.");
        }
        if (birthdate > DateTime.Now)
        {
            throw new ArgumentException("Birthdate cannot be in the future.");
        }
        var newUser = new User
        {
            Id = BaseService.GenerateRandomId(),
            Username = username,
            Password = password,
            Birthdate = birthdate
        };
        _database.Users.Add(newUser);
    }

    public void UpdateSettings(string userId, string? username, string? password, DateTime? birthdate)
    {
        var user = GetUserById(userId);
        if (user == null)
        {
            throw new UserNotFoundException($"User not found with ID: {userId}");
        }
        if (!string.IsNullOrEmpty(username))
        {
            if (_database.Users.Any(u => u.Username == username && u.Id != userId))
            {
                throw new UsernameAlreadyExistsException("Username already exists.");
            }
            user.Username = username;
        }
        if (!string.IsNullOrEmpty(password))
        {
            user.Password = password;
        }
        if (birthdate.HasValue)
        {
            if (birthdate.Value > DateTime.Now)
            {
                throw new ArgumentException("Birthdate cannot be in the future.");
            }
            user.Birthdate = birthdate.Value;
        }
    }
}
