namespace QuizGame.Services.Abstract;

public interface IQuestionService
{
    public List<string> GetCorrectOptions(string quizId, string questionId);

}
