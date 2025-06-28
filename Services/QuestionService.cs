using QuizGame.Entities;
using QuizGame.Services.Abstract;

namespace QuizGame.Services;

public class QuestionService : BaseService, IQuestionService
{
    public QuestionService(Database.Database database) : base(database)
    {
    }

    public List<string> GetCorrectOptions(Question question)
    {
        return question.CorrectAnswers;

    }

    public bool IsCorrect(Question question, List<string> answers)
    {
        return question.CorrectAnswers.SequenceEqual(answers);
    }
}
