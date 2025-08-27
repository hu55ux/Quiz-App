using QuizGame.Helper;

namespace QuizGame.Entities;

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public QuizCategory Category { get; set; }
    public virtual List<Question> Questions { get; set; } = new List<Question>();
    public int CorrectAnswersCount { get; set; } = 0;

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Category: {Category.ToString()}");
        Console.WriteLine("Questions:");
        foreach (var question in Questions)
        {
            question.Display();
        }
    }

}
