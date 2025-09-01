namespace QuizGame.Entities.DataTransferObjects;

public class UserScoreDto
{
    public string? Username { get; set; }
    public int Score { get; set; }
    override public string ToString()
    {
        return $"{Username}: {Score}";
    }
}

