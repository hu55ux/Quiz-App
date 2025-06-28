using QuizGame.Entities;
namespace QuizGame.Services.Abstract;

public interface IQuizService
{
    public List<string> GetQuizCategories();
    public Quiz? GetQuizByCategory(string category);
    public List<Question> GetQuestions(Quiz quiz, bool random = false);
    public Result? ResultQuiz(string category, string userId);
    public List<Result> GetResultsByUserId(string userId);
    public Question? GetQuestionById(string category, string questionId);
    public void SendResults(Result result);
    public void CorrectAnswer(Quiz quiz);
    public void AddQuestion(Quiz quiz, Question question);
    public void RemoveQuestion(Quiz quiz, string questionId);
    public void UpdateQuestion(Quiz quiz, Question question);
}
