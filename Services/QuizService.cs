using QuizGame.Entities;
using QuizGame.Helper;
using QuizGame.Services.Abstract;
namespace QuizGame.Services;

public class QuizService : BaseService, IQuizService
{
    public QuizService(Database.Database database) : base(database)
    {
    }


    public void CorrectAnswer(Quiz quiz)
    {
        quiz.CorrectAnswersCount++;
    }

    public Question? GetQuestionById(string category, string questionId)
    {
        var quiz = GetQuizByCategory(category);
        var question = quiz?.Questions?
            .FirstOrDefault(q => q.Id == questionId);
        return question;
    }

    public List<Question> GetQuestions(Quiz quiz, bool random = false)
    {
        var questions = quiz?.Questions;

        if (questions == null || !questions.Any())
        {
            return new List<Question>();
        }
        if (random)
        {
            Random randomizer = new Random();
            questions = questions.OrderBy(q => randomizer.Next()).ToList();
        }
        return questions.Take(20).ToList();
    }

    public Quiz? GetQuizByCategory(string category)
    {
        var quizByCategory = category?.Trim().ToLower();

        return quizByCategory switch
        {
            "history" => _database.HistoryQuiz,
            "geography" => _database.GeographyQuiz,
            "biology" => _database.BiologyQuiz,
            "mixed" => _database.MixedQuiz,
            _ => throw new ArgumentNullException($"Quiz with category '{category}' not found.")
        };

    }

    public List<string> GetQuizCategories()
    {
        var categories = new List<string>
        {
            QuizCategory.History.ToString(),
            QuizCategory.Geography.ToString(),
            QuizCategory.Biology.ToString(),
            QuizCategory.Mixed.ToString()
        };
        return categories;
    }



    public List<Result> GetResultsByUserId(string userId)
    {
        return _database?.Results?
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.Score)
            .Take(20)
            .ToList() ?? new List<Result>();


    }

    public Result? ResultQuiz(string category, string userId)
    {
        Quiz? quiz = GetQuizByCategory(category);
        User? user = _database?.Users?.FirstOrDefault(u => u.Id == userId);
        Result resultQuiz = new Result
        {
            QuizId = quiz?.Id ?? string.Empty,
            UserId = user?.Id ?? string.Empty,
            UserName = user?.Username ?? string.Empty,
            Score = quiz?.CorrectAnswersCount ?? 0,
        };

        return resultQuiz;
    }

    public void SendResults(Result result)
    {
        _database?.Results?.Add(result);
    }
    public void AddQuestion(Quiz quiz, Question question)
    {
        quiz.Questions.Add(question);
    }

    public void RemoveQuestion(Quiz quiz, string questionId)
    {
        quiz.Questions.RemoveAll(q => q.Id == questionId);
    }
    public void UpdateQuestion(Quiz quiz, Question question)
    {
        quiz.Questions.RemoveAll(q => q.Id == question.Id);
        quiz.Questions.Add(question);
    }

    public void StartQuiz(string category, string userId)
    {
        var quiz = GetQuizByCategory(category);
        var questions = GetQuestions(quiz, true);

        foreach (var question in questions)
        {
            Console.WriteLine($"Category: {quiz.Category.ToString()}");
            Console.WriteLine($"Question: {question.Text}");
            Console.WriteLine("Options:");
            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }
            Console.Write("Your answer (comma separated for multiple choice (1 - 4)): ");
            var userAnswer = Console.ReadLine()?.Trim();
            if (userAnswer == null)
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }
            var userAnswers = userAnswer.Split(',').Select(a => a.Trim()).ToList();
            if (question.isMultipleChoice)
            {
                if (userAnswers.All(a => question.CorrectAnswers.Contains(a)))
                {
                    CorrectAnswer(quiz);
                    Console.WriteLine("Correct answer!");
                }
                else
                {
                    Console.WriteLine("Incorrect answer.");
                }
            }
            else
            {
                if (userAnswers.Count == 1 && question.CorrectAnswers.Contains(userAnswers[0]))
                {
                    CorrectAnswer(quiz);
                    Console.WriteLine("Correct answer!");
                }
                else
                {
                    Console.WriteLine("Incorrect answer.");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        var result = ResultQuiz(category, userId);
        if (result != null)
        {
            SendResults(result);
            Console.WriteLine($"Quiz completed! Your score: {result.Score}");
        }
        else
        {
            Console.WriteLine("Error calculating results.");
        }

    }

    public List<Result> GetResultByCategory(string category)
    {
        return _database?.Results?
            .Where(r => r.QuizId == GetQuizByCategory(category)?.Id)
            .OrderByDescending(r => r.Score)
            .Take(20)
            .ToList() ?? new List<Result>();
    }
}
