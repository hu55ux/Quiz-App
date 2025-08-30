using QuizGame.Entities;
namespace QuizGame.Services.Abstract;

public interface IQuestionService
{
    public void AddQuestion(Question question);
    public Question? CreateQuestion();
    public Question? GetQuestionById(int id);
    public List<Answer> GetCorrectOptions(Question question);
    public List<Question> GetAllQuestions(Quiz quiz);
    public void UpdateQuestion(Question question);
    public void DeleteQuestion(int id);
}
