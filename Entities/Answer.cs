namespace QuizGame.Entities;

public class Answer
{
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; } = false;
    public int QuestionId { get; set; }
    public virtual Question Question { get; set; }

    public void Display()
    {
        Console.WriteLine($"Text: {Text}");
    }
}
