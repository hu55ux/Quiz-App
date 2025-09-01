using QuizGame.Entities;
using QuizGame.Entities.DataTransferObjects;
namespace QuizGame.Services.Abstract;

public interface IQuizService
{
    public Quiz? GetQuizByCategory();
    public List<Question> GetQuestions(Quiz quiz, bool random = false);
    public List<UserScoreDto>? ResultQuizByCategory();
    public List<UserScoreById> GetResultsByUserId(int userId);
    public void StartQuiz(int userId);
}
