namespace QuizGame.Entities;

public class Result
{
    public string QuizId { get; set; } = string.Empty;
    public int Score { get; set; } = 0;

    override public string ToString()
    {
        return $"Quiz ID: {QuizId}, Score: {Score}";
    }
}
