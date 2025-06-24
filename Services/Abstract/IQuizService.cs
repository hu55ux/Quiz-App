using QuizGame.Entities;

namespace QuizGame.Services.Abstract;

public interface IQuizService
{
    public List<string> GetQuizCategories();
    public Quiz? GetQuizByCategory(string category);
    public Quiz? GetQuizById(string quizId);
    public List<Question> GetQuestionsByQuizId(string quizId);
    public Result? SubmitQuiz(string quizId, string userId, List<string> answers);
    public List<Result> GetResultsByUserId(string userId);
}
