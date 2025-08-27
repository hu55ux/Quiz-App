//using System.Text.RegularExpressions;
//using QuizGame.Entities;
//using QuizGame.Exceptions;
//using QuizGame.Services.Abstract;

//namespace QuizGame.Services;

//public class UserService : BaseService, IUserService
//{
//    public UserService(Database.Database database) : base(database)
//    {
//    }
//    public bool ValidateUsername(string username)
//    {
//        // Ən az 8 simvol, ən az 1 böyük hərf, ən az 1 rəqəm
//        var usernameRegex = new Regex(@"^(?=.*[A-Z])(?=.*\d).{8,}$");
//        return usernameRegex.IsMatch(username);
//    }

//    public bool ValidatePassword(string password)
//    {
//        // Dəqiq 8 simvol, ən az 2 rəqəm, ən az 1 xüsusi simvol, yalnız kiçik hərflər
//        var passwordRegex = new Regex(@"^(?=(.*\d){2})(?=.*[!@#$%^&*]).{8}$");
//        return password.Length == 8 &&
//               password.ToLower() == password &&
//               passwordRegex.IsMatch(password);
//    }
//    public void DeleteUser(string userId)
//    {
//        if (string.IsNullOrEmpty(userId))
//        {
//            throw new UserNotFoundException("User ID cannot be null or empty.");
//        }
//        _database?.Users?.RemoveAll(u => u.Id == userId);
//    }

//    public User? GetUserById(string userId)
//    {
//        var user = _database.Users?.FirstOrDefault(u => u.Id == userId);
//        if (user == null)
//        {
//            throw new UserNotFoundException($"User not found with ID: {userId}");
//        }
//        return user;
//    }

//    public User? Login(string username, string password)
//    {
//        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//        {
//            throw new ArgumentException("Username and password cannot be empty.");
//        }
//        if (_database.Users == null)
//        {
//            throw new UserNotFoundException("No users found in the database.");
//        }
//        if (_database.Users.Any(u => u.Username == username && u.Password == password))
//        {
//            return _database.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
//        }
//        return null;
//    }

//    public void Register(string username, string password, DateTime birthdate)
//    {
//        if (_database.Users.Any(u => u.Username == username))
//        {
//            throw new UsernameAlreadyExistsException("Username already exists.");
//        }
//        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//        {
//            throw new ArgumentException("Username and password cannot be empty.");
//        }
//        if (birthdate > DateTime.Now)
//        {
//            throw new ArgumentException("Birthdate cannot be in the future.");
//        }
//        User newUser = new User(Guid.NewGuid().ToString(), username, password, birthdate);
//        _database.Users.Add(newUser);
//    }

//    public void UpdateSettings(string userId, string? username, string? password, DateTime? birthdate)
//    {
//        var user = GetUserById(userId);
//        if (user == null)
//        {
//            throw new UserNotFoundException($"User not found with ID: {userId}");
//        }
//        if (!string.IsNullOrEmpty(username))
//        {
//            if (_database.Users.Any(u => u.Username == username && u.Id != userId))
//            {
//                throw new UsernameAlreadyExistsException("Username already exists.");
//            }
//            user.Username = username;
//        }
//        if (!string.IsNullOrEmpty(password))
//        {
//            user.Password = password;
//        }
//        if (birthdate.HasValue)
//        {
//            if (birthdate.Value > DateTime.Now)
//            {
//                throw new ArgumentException("Birthdate cannot be in the future.");
//            }
//            user.Birthdate = birthdate.Value;
//        }
//    }

//    public bool ValidateBirthdate(DateTime birthdate)
//    {
//        int yearNow = DateTime.Now.Year;
//        int birthtadeYear = birthdate.Year;
//        if (yearNow - birthtadeYear < 18)
//        {
//            return false; // User must be at least 18 years old
//        }
//        return true; // User is 18 or older
//    }
//}
