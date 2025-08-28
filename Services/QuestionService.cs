using QuizGame.Entities;
using QuizGame.Services.Abstract;

namespace QuizGame.Services;

public class QuestionService : BaseService, IQuestionService
{
    public QuestionService(QuizGameDBContext database) : base(database)
    {
    }

    public List<Answer> GetCorrectOptions(Question question)
    {
        return question.Answers.Where(a => a.IsCorrect).ToList();

    }
}
