using System.Text.RegularExpressions;
using QuizGame.Entities;

namespace QuizGame.Helper;

public static class ValidationData_s
{
    public static bool ValidateUsername(string username)
    {
        // Ən az 8 simvol, ən az 1 böyük hərf, ən az 1 rəqəm
        var usernameRegex = new Regex(@"^(?=.*[A-Z])(?=.*\d).{8,}$");
        return usernameRegex.IsMatch(username);
    }

    public static bool ValidatePassword(string password)
    {
        // Dəqiq 8 simvol, ən az 2 rəqəm, ən az 1 xüsusi simvol, yalnız kiçik ahərflər
        var passwordRegex = new Regex(@"^(?=(.*\d){2})(?=.*[!@#$%^&*]).{8}$");
        return password.Length == 8 &&
               password.ToLower() == password &&
               passwordRegex.IsMatch(password);
    }

    public static bool ValidateBirthdate(DateTime birthdate)
    {
        int yearNow = DateTime.Now.Year;
        int birthtadeYear = birthdate.Year;
        if (yearNow - birthtadeYear < 18)
        {
            return false; // User must be at least 18 years old
        }
        return true; // User is 18 or older
    }

    public static bool IsUniqueUsername(QuizGameDBContext _database, string username, int? userId = null)
    {
        if (userId.HasValue)
        {
            // Update zamanı başqa istifadəçilərə bax
            return !_database.Users.Any(u => u.Username == username && u.Id != userId.Value);
        }
        else
        {
            // Register zamanı bütün istifadəçilərə bax
            return !_database.Users.Any(u => u.Username == username);
        }
    }

   

}
