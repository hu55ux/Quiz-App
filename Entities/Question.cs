namespace QuizGame.Entities;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool isMultipleChoice { get; set; } = false;
    public virtual List<Answer> Answers { get; set; } = new();
    public int QuizId { get; set; }
    public virtual Quiz Quiz { get; set; }



    public void Display()
    {
        Console.WriteLine($"Text: {Text}");
        Console.WriteLine($"Is Multiple Choice: {isMultipleChoice}");
        Console.WriteLine("Answers:");
        foreach (var answer in Answers)
        {
            answer.Display();
        }
    }
}
