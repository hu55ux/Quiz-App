using System.Linq.Expressions;
using QuizGame.Entities;
using QuizGame.Services.Abstract;

namespace QuizGame;

public class Program
{


    public static readonly string WelcomeMessage = @"
🧠 Welcome to the General Knowledge Quiz!

Get ready to test your brain with 4 exciting topics, each with 20 fun and challenging questions.

📚 Topics Available:
1. History    - Key events, famous figures, and ancient times.
2. Biology    - Life, organisms, and the human body.
3. Geography  - Countries, capitals, and physical features.
4. Mixed      - A surprise mix from all categories.

🔍 Quiz Info:
- 20 questions per topic
- Multiple choice format
- Only one correct answer per question

✅ Tips:
- Read each question carefully
- No pressure — just learn and enjoy!
- You can switch topics anytime

🎯 Are you ready? Choose a topic to begin!
";

    public void DisplayMenu()
    {
        Database.Database database = new Database.Database();
        IQuestionService questionService = new Services.QuestionService(database);
        IUserService userService = new Services.UserService(database);
        IQuizService quizService = new Services.QuizService(database);


        int choice = 0;
        string[] choices = { "Login", "Register", "Exit" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Use arrow keys to navigate and Enter to select.\n\n");
            for (int i = 0; i < choices.Length; i++)
            {
                if (i == choice)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{i + 1}. {choices[i]}. <- ");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"{i + 1}. {choices[i]}.");
                }
                Console.ResetColor();
            }

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    choice = (choice > 0) ? choice - 1 : choices.Length - 1;
                    break;
                case ConsoleKey.DownArrow:
                    choice = (choice < choices.Length - 1) ? choice + 1 : 0;
                    break;
                case ConsoleKey.Enter:
                    Console.WriteLine($"\nYou selected: {choices[choice]}.\nPress any key to continue...");
                    Console.ReadKey();
                    switch (choice)
                    {
                        case 0:
                            //Login
                            User? user = DisplayLogin(database, userService);
                            if (user != null)
                            {
                                Console.Clear();
                                Console.WriteLine(WelcomeMessage);
                                string[] choicesLogin = {
                                    "History Quiz",
                                    "Biology Quiz",
                                    "Geography Quiz",
                                    "Mixed Quiz",
                                    "View Results",
                                    "Update personal information",
                                    "Logout"
                                };
                                int choiceLogin = 0;
                                while (true)
                                {
                                    Console.WriteLine("Use arrow keys to navigate and Enter to select.\n\n");
                                    for (int i = 0; i < choicesLogin.Length; i++)
                                    {
                                        if (i == choiceLogin)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine($"{i + 1}. {choicesLogin[i]}. <- ");
                                        }
                                        else
                                        {
                                            Console.ResetColor();
                                            Console.WriteLine($"{i + 1}. {choicesLogin[i]}.");
                                        }
                                        Console.ResetColor();
                                    }
                                    switch (Console.ReadKey(true).Key)
                                    {
                                        case ConsoleKey.UpArrow:
                                            choiceLogin = (choiceLogin > 0) ? choiceLogin - 1 : choicesLogin.Length - 1;
                                            break;
                                        case ConsoleKey.DownArrow:
                                            choiceLogin = (choiceLogin < choicesLogin.Length - 1) ? choiceLogin + 1 : 0;
                                            break;
                                        case ConsoleKey.Enter:
                                            Console.WriteLine($"\nYou selected: {choicesLogin[choiceLogin]}.\nPress any key to continue...");
                                            switch (choiceLogin)
                                            {
                                                case 0:
                                                    quizService.StartQuiz("History", user.Id);
                                                    break;
                                                case 1:
                                                    quizService.StartQuiz("Biology", user.Id);
                                                    break;
                                                case 2:
                                                    quizService.StartQuiz("Geography", user.Id);
                                                    break;
                                                case 3:
                                                    quizService.StartQuiz("Mixed", user.Id);
                                                    break;
                                                case 4:
                                                    string[] choicesResult = { "View All Results for this category.", "View My Results.", "Back." };
                                                    int choiceResult = 0;
                                                    for (int i = 0; i < choicesResult.Length; i++)
                                                    {
                                                        if (i == choiceResult)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                                            Console.WriteLine($"{i + 1}. {choicesResult[i]}. <- ");
                                                        }
                                                        else
                                                        {
                                                            Console.ResetColor();
                                                            Console.WriteLine($"{i + 1}. {choicesResult[i]}.");
                                                        }
                                                        Console.ResetColor();
                                                    }
                                                    switch (Console.ReadKey(true).Key)
                                                    {
                                                        case ConsoleKey.UpArrow:
                                                            choiceResult = (choiceResult > 0) ? choiceResult - 1 : choicesResult.Length - 1;
                                                            break;
                                                        case ConsoleKey.DownArrow:
                                                            choiceResult = (choiceResult < choicesResult.Length - 1) ? choiceResult + 1 : 0;
                                                            break;
                                                        case ConsoleKey.Enter:
                                                            Console.WriteLine($"\nYou selected: {choicesResult[choiceResult]}.\nPress any key to continue...");
                                                            switch (choiceResult)
                                                            {
                                                                case 0:
                                                                    var resultsByCategory = quizService.GetResultByCategory(choicesLogin[choiceLogin]);
                                                                    foreach (var result in resultsByCategory)
                                                                    {
                                                                        Console.WriteLine($"User: {result.UserName}, Score: {result.Score}");
                                                                    }
                                                                    break;
                                                                case 1:
                                                                    var resultByUserID = quizService.GetResultsByUserId(user.Id);
                                                                    foreach (var result in resultByUserID)
                                                                    {
                                                                        Console.WriteLine($"Quiz: {result.QuizId}, Score: {result.Score}");
                                                                    }
                                                                    break;
                                                                case 2:
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                    }
                                                    break;
                                                    case 5:
                                                    Console.WriteLine("Update personal information.");
                                                    Console.Write("Enter new username: ");
                                                    string newUsername = Console.ReadLine()?.Trim() ?? string.Empty;
                                                    Console.Write("Enter new password: ");
                                                    string newPassword = Console.ReadLine()?.Trim() ?? string.Empty;
                                                    Console.Write("Enter new birthdate (yyyy-mm-dd): ");
                                                    DateTime newBirthdate;
                                                    while (!DateTime.TryParse(Console.ReadLine(), out newBirthdate))
                                                    {
                                                        Console.Write("Invalid date format. Please enter your birthdate (yyyy-mm-dd): ");
                                                    }
                                                    try
                                                    {
                                                        userService.UpdateSettings(user.Id, newUsername, newPassword, newBirthdate);
                                                        Console.WriteLine("Personal information updated successfully.");
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine($"Error: {ex.Message}");
                                                    }
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                }
                            }
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid selection. Use arrow keys to navigate and Enter to select.");
                    break;
            }


        }
    }

    public User? DisplayLogin(Database.Database database, IUserService userService)
    {
        Console.Clear();
        Console.WriteLine("📝 Login to your account\n");
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

    public void DisplayRegister(Database.Database database, IUserService userService)
    {
        Console.Clear();
        Console.WriteLine("📝 Register a new account\n");
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
                database.Users.Add(user);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }



    static void Main(string[] args)
    {
        Database.Database database = new Database.Database();
        IQuestionService questionService = new Services.QuestionService(database);

    }

}

