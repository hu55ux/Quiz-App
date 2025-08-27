namespace QuizGame.Entities;

public class Result
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int QuizId { get; set; }
    public virtual Quiz Quiz { get; set; }
    public int Score { get; set; }

    public void Display()
    {
       
    }

   }
