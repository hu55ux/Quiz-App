namespace QuizGame.Entities;

public class Question
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new List<string>();
    public List<string> CorrectAnswers { get; set; } = new List<string>();
    public bool isMultipleChoice { get; set; } = false;

    public void Display()
    {
        Console.WriteLine($"Question ID: {Id}");
        Console.WriteLine($"Text: {Text}");
        Console.WriteLine("Options:");
        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
    }
}
