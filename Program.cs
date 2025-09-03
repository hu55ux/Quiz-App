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
        using (QuizGameDBContext database = new QuizGameDBContext())
        {

            var IQuizService = new QuizService(database);
            var IQuestionService = new QuestionService(database);
            var IUserService = new UserService(database);
            database.EnsureSeedData();

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
                        case 1: // Login
                            User? user = Display.DisplayLogin(database, IUserService);
                            if (user != null)
                            {
                                Console.WriteLine("Login successful!");

                                while (!exitMenu)
                                {
                                    int choiceLogin = Display.DisplayUserMenu(user);
                                    Console.WriteLine(WelcomeMessage);

                                    switch (choiceLogin)
                                    {
                                        case 1:
                                            IQuizService.StartQuiz(user.Id);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        case 2:
                                            var results = IQuizService.GetResultsByUserId(user.Id);
                                            foreach (var result in results)
                                            {
                                                Console.WriteLine(result);
                                            }
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        case 3:
                                            var resultsByCategory = IQuizService.ResultQuizByCategory();
                                            foreach (var result in resultsByCategory)
                                            {
                                                Console.WriteLine(result);
                                            }
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        case 4:
                                            IUserService.UpdateUserData(database, user.Id);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        case 5:
                                            Console.WriteLine("Logging out...");
                                            user = null; // Clear user session
                                            Console.WriteLine("Exiting the quiz. Thank you for playing!");
                                            exitMenu = true; // Exit the inner loop to return to the main menu
                                            Thread.Sleep(1421);
                                            break;
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Login failed. Please try again.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            break;
                        case 2: // Register
                            Display.DisplayRegister(database, IUserService);
                            break;
                        case 3:
                            Console.WriteLine("Exiting the quiz. Thank you for playing!");
                            Thread.Sleep(1421);
                            return;
                    }
                    break;
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
                    database.SaveChanges();
                }
            }
        }
    }
    static void Main(string[] args)
    {
        Program program = new Program();
        program.DisplayMenu();
    }

}

