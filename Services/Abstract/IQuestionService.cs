using QuizGame.Entities;
namespace QuizGame.Services.Abstract;

public interface IQuestionService
{
    public List<string> GetCorrectOptions(Question question);
    public bool IsCorrect(Question question,List<string> answers);
}
