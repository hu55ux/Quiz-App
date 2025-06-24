using QuizGame.Helper;

namespace QuizGame.Entities;

public class Quiz
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public QuizCategory Category { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public int CorrectAnswersCount { get; set; } = 0;

    public void Display()
    {
        Console.WriteLine($"Quiz ID: {Id}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Category: {Category.ToString()}");
        Console.WriteLine("Questions:");
        foreach (var question in Questions)
        {
            question.Display();
        }
    }

}
