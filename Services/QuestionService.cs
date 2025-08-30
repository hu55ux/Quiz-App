using QuizGame.Entities;
using QuizGame.Helper;
using QuizGame.Services.Abstract;

namespace QuizGame.Services;

public class QuestionService : BaseService, IQuestionService
{
    public QuestionService(QuizGameDBContext database) : base(database)
    {
    }

    public void AddQuestion(Question question)
    {
        _database.Questions.Add(question);
        _database.SaveChanges();
    }

    public void DeleteQuestion(int id)
    {
        var question = GetQuestionById(id);
        if (question != null)
        {
            _database.Questions.Remove(question);
            _database.SaveChanges();
        }
    }

    public List<Question> GetAllQuestions(Quiz quiz)
    {
        var questions = quiz.Questions;
        return questions;
    }

    public List<Answer> GetCorrectOptions(Question question)
    {
        var correctAnswers = question.Answers.Where(ans => ans.IsCorrect).ToList();
        return correctAnswers;
    }

    public Question? GetQuestionById(int id)
    {
        var question = _database.Questions.FirstOrDefault(ques => id == ques.Id);
        return question;
    }

    public Question? CreateQuestion()
    {
        Question question = new QuestionCreateHelper()
            .SetText()
            .SetOptions()
            .SetCorrectAnswers()
            .Build();
        return question;
    }

    public void UpdateQuestion(Question question)
    {
        new UpdateHelper(question)
            .UpdateText()
            .UpdateMultipleChoice()
            .UpdateAnswers()
            .Build();
        Console.WriteLine("Question updated successfully.");
        _database.SaveChanges();
    }
}
