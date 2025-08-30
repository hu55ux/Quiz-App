using QuizGame.Entities;

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
}
