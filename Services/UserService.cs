using QuizGame.Entities;
using QuizGame.Exceptions;
using QuizGame.Helper;
using QuizGame.Services.Abstract;

namespace QuizGame.Services;

public class UserService : BaseService, IUserService
{
    public UserService(QuizGameDBContext database) : base(database)
    {
    }
    public bool DeleteUser(int userId)
    {
        var user = GetUserById(userId);
        if (user == null) return false;

        _database.Users.Remove(user);
        _database.SaveChanges();
        return true;
    }

    public User? GetUserById(int userId)
    {
        User? user = _database.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new UserNotFoundException($"User not found with ID: {userId}");
        }
        return user;
    }

    public User? Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Username and password cannot be empty.");
        string hashedPassword = PasswordHelper.HashPassword(password);
        var user = _database.Users
                    .FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
        if (user == null)
            throw new UserNotFoundException("Invalid username or password.");
        return user;
    }

    public void Register(string username, string password, DateTime birthdate)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Username and password cannot be empty.");
        if (!ValidationData_s.ValidateBirthdate(birthdate))
            throw new ArgumentException("User must be at least 18 years old.");
        if (!ValidationData_s.ValidateUsername(username))
            throw new ArgumentException("Username must be at least 8 characters, include 1 uppercase letter and 1 number.");
        if (!ValidationData_s.ValidatePassword(password))
            throw new ArgumentException("Password must be exactly 8 characters, contain at least 2 digits, 1 special character, and only lowercase letters.");
        if (!ValidationData_s.IsUniqueUsername(_database, username))
            throw new UsernameAlreadyExistsException("Username already exists.");
        string hashedPassword = PasswordHelper.HashPassword(password);
        User newUser = new User
        {
            Username = username,
            Password = hashedPassword,
            Birthdate = birthdate
        };
        _database.Users.Add(newUser);
        _database.SaveChanges();
    }

    public void UpdateSettings(int userId, string? username, string? password, DateTime? birthdate)
    {
        var user = GetUserById(userId);
        if (user == null)
            throw new UserNotFoundException($"User not found with ID: {userId}");
        if (!string.IsNullOrWhiteSpace(username))
        {
            if (!ValidationData_s.ValidateUsername(username))
                throw new ArgumentException("Username must be at least 8 characters, include 1 uppercase letter and 1 number.");
            if (!ValidationData_s.IsUniqueUsername(_database, username, userId))
                throw new UsernameAlreadyExistsException("Username already exists.");
            user.Username = username;
        }
        if (!string.IsNullOrWhiteSpace(password))
        {
            if (!ValidationData_s.ValidatePassword(password))
                throw new ArgumentException("Password must be exactly 8 characters, contain at least 2 digits, 1 special character, and only lowercase letters.");
            user.Password = PasswordHelper.HashPassword(password);
        }
        if (birthdate.HasValue)
        {
            if (!ValidationData_s.ValidateBirthdate(birthdate.Value))
                throw new ArgumentException("User must be at least 18 years old.");
            user.Birthdate = birthdate.Value;
        }
        _database.SaveChanges();
    }
}
