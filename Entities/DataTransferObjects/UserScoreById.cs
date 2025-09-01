namespace QuizGame.Entities.DataTransferObjects
{
    public class UserScoreById
    {
        public string? Username { get; set; }
        public string? Quiztitle { get; set; }
        public int Score { get; set; }
        override public string ToString()
        {
            return $"Username: {Username}, Quiz Title: {Quiztitle}, Score: {Score}";
        }
    }
}
