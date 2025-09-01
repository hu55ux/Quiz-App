using QuizGame.Entities;
using QuizGame.Services.Abstract;

namespace QuizGame.Helper;

public static class Display
{
    public static string? SelectionCategoryForQuiz()
    {
        List<string> categories = new List<string>
        {
            QuizCategory.History.ToString(),
            QuizCategory.Geography.ToString(),
            QuizCategory.Biology.ToString(),
            QuizCategory.Mixed.ToString()
        };
        int choice = 0;

        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Use arrow keys to navigate and Enter to select.\n");

                for (int i = 0; i < categories.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"{i + 1}. {categories[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {categories[i]}");
                    }
                    Console.ResetColor();
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        choice = (choice == 0) ? categories.Count - 1 : choice - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        choice = (choice == categories.Count - 1) ? 0 : choice + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine($"You selected: {categories[choice]}");
                        return categories[choice];
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }

    public static QuizCategory GetCategory()
    {
        string[] categories = { "History", "Biology", "Geography", "Mixed" };
        for (int i = 0; i < categories.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i]}");
        }
        Console.Write("Select a category (1-4): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > categories.Length)
        {
            Console.Write("Invalid choice. Please select a category (1-4): ");
        }
        switch (choice)
        {
            case 1:
                return QuizCategory.History;
            case 2:
                return QuizCategory.Biology;
            case 3:
                return QuizCategory.Geography;
            case 4:
                return QuizCategory.Mixed;
            default:
                return QuizCategory.Mixed;
        }
    }
    public static User? DisplayLogin(QuizGameDBContext database, IUserService userService)
    {
        Console.Clear();
        Console.WriteLine("Login to your account\n");
        Console.Write("Username: ");
        string username = Console.ReadLine()?.Trim() ?? string.Empty;
        Console.Write("Password: ");
        string password = Console.ReadLine()?.Trim() ?? string.Empty;
        try
        {
            User? user = userService.Login(username, password);
            if (user != null)
            {
                Console.WriteLine($"Welcome back, {user.Username}!");
                return user;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }

    public static void DisplayRegister(QuizGameDBContext database, IUserService userService)
    {
        Console.Clear();
        Console.WriteLine("Register a new account\n");
        Console.Write("Username: ");
        string username = Console.ReadLine()?.Trim() ?? string.Empty;
        Console.Write("Password: ");
        string password = Console.ReadLine()?.Trim() ?? string.Empty;
        Console.Write("Birthdate (yyyy-mm-dd): ");
        DateTime birthdate;
        while (!DateTime.TryParse(Console.ReadLine(), out birthdate))
        {
            Console.Write("Invalid date format. Please enter your birthdate (yyyy-mm-dd): ");
        }
        try
        {
            userService.Register(username, password, birthdate);
            User? user = userService.Login(username, password);
            if (user != null)
            {
                Console.WriteLine($"Registration successful! Welcome, {user.Username}!");
                database?.Users?.Add(user);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static int DisplayMainMenu()
    {
        List<string> choices = new List<string>
        {
            "Login",
            "Register",
            "Exit"
        };
        int choice = 0;
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Use arrow keys to navigate and Enter to select.\n");
                for (int i = 0; i < choices.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"{i + 1}. {choices[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {choices[i]}");
                    }
                    Console.ResetColor();
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        choice = (choice == 0) ? choices.Count - 1 : choice - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        choice = (choice == choices.Count - 1) ? 0 : choice + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine($"You selected: {choices[choice]}");
                        return choice + 1;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }
        }
    }
    public static int DisplayUserMenu(User user)
    {
        List<string> choices = new List<string>
        {
            "History Quiz",
            "Biology Quiz",
            "Geography Quiz",
            "Mixed Quiz",
            "View Results",
            "Update personal information",
            "Logout"
        };
        int choice = 0;


        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Use arrow keys to navigate and Enter to select.\n");
                for (int i = 0; i < choices.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"{i + 1}. {choices[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {choices[i]}");
                    }
                    Console.ResetColor();
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        choice = (choice == 0) ? choices.Count - 1 : choice - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        choice = (choice == choices.Count - 1) ? 0 : choice + 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine($"You selected: {choices[choice]}");
                        return choice + 1;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }

        }
    }

}
