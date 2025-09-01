using QuizGame.Entities;
using QuizGame.Exceptions;
using QuizGame.Helper;
using QuizGame.Services;

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
        var database = new QuizGameDBContext();
        var questionService = new QuestionService(database);
        var userService = new UserService(database);
        var quizService = new QuizService(database);

        while (true)
        {
            try
            {
                int choice = Display.DisplayMainMenu();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                bool exitMenu = false;
                switch (choice)
                {
                    case 0: // Login
                        User? user = Display.DisplayLogin(database, userService);
                        if (user != null)
                        {

                            int choiceLogin = Display.DisplayUserMenu(user);
                            while (!exitMenu)
                            {
                                Console.Clear();
                                Console.WriteLine(WelcomeMessage);
                                Console.WriteLine("Use arrow keys to navigate and Enter to select.\n");

                                for (int i = 0; i < choicesLogin.Length; i++)
                                {
                                    if (i == choiceLogin)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine($"{i + 1}. {choicesLogin[i]} <-");
                                    }
                                    else
                                    {
                                        Console.ResetColor();
                                        Console.WriteLine($"{i + 1}. {choicesLogin[i]}");
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
                                        Console.ReadKey();

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
                                                string[] choicesResult =
                                                    {
                "View All Results for this category.",
                "View My Results.",
                "Back"
            };
                                                int choiceResult = 0;
                                                bool exitResultsMenu = false;
                                                while (!exitResultsMenu)  // Added while loop for Results Menu
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Results Menu\n");

                                                    for (int i = 0; i < choicesResult.Length; i++)
                                                    {
                                                        if (i == choiceResult)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                                            Console.WriteLine($"{i + 1}. {choicesResult[i]} <-");
                                                        }
                                                        else
                                                        {
                                                            Console.ResetColor();
                                                            Console.WriteLine($"{i + 1}. {choicesResult[i]}");
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
                                                            Console.ReadKey();

                                                            switch (choiceResult)
                                                            {
                                                                case 0:
                                                                    Console.Clear();
                                                                    var category = GetCategory().ToString();
                                                                    Console.WriteLine("Category selected: " + category);
                                                                    var resultsCategory = quizService.GetResultByCategory(category);
                                                                    foreach (var result in resultsCategory)
                                                                    {
                                                                        Console.WriteLine(result);
                                                                        Console.WriteLine();
                                                                    }
                                                                    Console.WriteLine("Press any key to continue...");
                                                                    Console.ReadKey();
                                                                    break;
                                                                case 1:
                                                                    Console.Clear();
                                                                    var myResults = quizService.GetResultsByUserId(user.Id);
                                                                    foreach (var result in myResults)
                                                                    {
                                                                        Console.WriteLine(result);
                                                                        Console.WriteLine();
                                                                    }
                                                                    Console.WriteLine("Press any key to continue...");
                                                                    Console.ReadKey();
                                                                    break;
                                                                case 2:
                                                                    exitResultsMenu = true; // Exit the results menu
                                                                    break; // Continue to the outer loop to return to the main menu
                                                            }
                                                            break;
                                                    }

                                                }
                                                break;
                                            case 5:
                                                Console.Clear();
                                                Console.Write($"Enter new username (current: {user?.Username}): ");
                                                string newUsername = Console.ReadLine()?.Trim() ?? string.Empty;

                                                Console.Write($"Enter new password (current: {user?.Password}): ");
                                                string newPassword = Console.ReadLine()?.Trim() ?? string.Empty;

                                                Console.Write($"Enter new birthdate (yyyy-mm-dd) (current: {user?.Birthdate.ToShortTimeString()}) : ");
                                                DateTime newBirthdate;
                                                while (!DateTime.TryParse(Console.ReadLine(), out newBirthdate))
                                                {
                                                    Console.Write("Invalid date. Try again (yyyy-mm-dd): ");
                                                }

                                                try
                                                {
                                                    userService.UpdateSettings(user.Id, newUsername, newPassword, newBirthdate);
                                                    Console.WriteLine("Updated successfully.");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine($"Error: {ex.Message}");
                                                }

                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadKey();
                                                break;

                                            case 6:
                                                Console.WriteLine("Logging out...");
                                                user = null; // Clear user session
                                                Console.WriteLine("Exiting the quiz. Thank you for playing!");
                                                exitMenu = true; // Exit the inner loop to return to the main menu
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please try again.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case 1: // Register
                        DisplayRegister(database, userService);
                        break;
                }

                break;

                default:
                            Console.WriteLine("Invalid key. Use arrow keys and Enter.");
                break;
            }
                }
                catch (UserNotFoundException ex)
                {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }
                catch (UsernameAlreadyExistsException ex)
                {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }
                catch (WrongInputException ex)
                {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }
                catch (Exception ex)
                {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }
                finally
                {
            database.SaveAll();
        }
    }
    }









    static void Main(string[] args)
    {
        Program program = new Program();

        using (QuizGameDBContext database = new QuizGameDBContext())
        {
            var IQuizService = new QuizService(database);
            var IQuestionService = new QuestionService(database);
            var IUserService = new UserService(database);
            database.EnsureSeedData();













            database.SaveChanges();
        }
        Console.WriteLine();
        //program.DisplayMenu();

    }

}

