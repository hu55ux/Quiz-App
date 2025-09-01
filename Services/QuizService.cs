using Microsoft.EntityFrameworkCore;
using QuizGame.Entities;
using QuizGame.Entities.DataTransferObjects;
using QuizGame.Helper;
using QuizGame.Services.Abstract;
namespace QuizGame.Services;

public class QuizService : BaseService, IQuizService
{
    public QuizService(QuizGameDBContext database) : base(database)
    {
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

    public Quiz? GetQuizByCategory()
    {
        string? quizCategory = Display.SelectionCategoryForQuiz();
        var quiz = _database.Quizzes.Include(q => q.Questions).ThenInclude(a => a.Answers).FirstOrDefault(q => q.Category.ToString() == quizCategory);
        return quiz;
    }
    public List<UserScoreById> GetResultsByUserId(int userId)
    {
        var result = _database?
            .Results
            .Include(r => r.Quiz)
            .Include(q => q.User)
            .Where(r => r.UserId == userId)
            .Select(r => new UserScoreById
            {
                Username = r.User.Username,
                Quiztitle = r.Quiz.Title,
                Score = r.Score
            })
            .OrderByDescending(r => r.Score)
            .ToList();
        return result;
    }

    public List<UserScoreDto> ResultQuizByCategory()
    {
        string? category = Display.SelectionCategoryForQuiz();
        var quizResults = _database.Results
           .Include(u => u.User)
           .Include(q => q.Quiz)
           .Where(r => r.Quiz.Category.ToString() == category)
           .Select(r => new UserScoreDto
           {
               Username = r.User.Username,
               Score = r.Score
           })
           .OrderByDescending(r => r.Score)
           .ToList();

        return quizResults;
    }

    public void StartQuiz(int userId)
    {
        try
        {
            // Quiz-i verilən kateqoriyaya görə yükləyirik
            var quiz = GetQuizByCategory();
            if (quiz == null)
            {
                Console.WriteLine($"No quiz found!!");
                return;
            }

            // Sualları qarışdıraraq yükləyirik
            var questions = GetQuestions(quiz, random: true);
            if (questions == null || !questions.Any())
            {
                Console.WriteLine("No questions available for this quiz.");
                return;
            }

            int correctAnswers = 0;

            // Hər bir sual üçün dövr edirik
            foreach (var question in questions)
            {
                Console.Clear();
                Console.WriteLine($"Category: {quiz.Category}");
                Console.WriteLine($"\nQuestion: {question.Text}\n");

                // Seçimləri göstəririk
                Console.WriteLine("Options:");
                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
                }

                // İstifadəçi cavabını alırıq və yoxlayırıq
                List<int> userAnswers;
                while (true)
                {
                    Console.Write($"\nYour answer {(question.isMultipleChoice ? "(comma separated numbers 1-4)" : "(single number)")}: ");
                    var input = Console.ReadLine()?.Trim();

                    // Boş daxil etməni yoxlayırıq
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        continue;
                    }

                    // Cavabları vergüllə ayıraraq listə çeviririk
                    var userAnswersPars = input.Split(',')
                                    .Select(a => a.Trim())
                                    .Where(a => int.TryParse(a, out int num) && num >= 1 && num <= question.Answers.Count)
                                    .Select(int.Parse)
                                    .ToList();

                    if (!userAnswersPars.Any())
                    {
                        Console.WriteLine("Invalid input. Please enter valid numbers.");
                        continue;
                    }
                    Console.WriteLine($"Please enter numbers between 1 and {question.Answers.Count}");
                    userAnswers = userAnswersPars;
                    break;
                }

                bool isCorrect = false;
                // Cavabın düzgün olub olmadığını yoxlayırıq
                if (question.isMultipleChoice)
                {
                    var correctAnswerIndexes = question.Answers
                                                       .Where(a => a.IsCorrect)
                                                       .Select(a => question.Answers
                                                       .IndexOf(a) + 1)
                                                       .ToList();
                    isCorrect = correctAnswerIndexes.Count == userAnswers.Count && correctAnswerIndexes.All(userAnswers.Contains);


                }
                else
                {
                    isCorrect = question.Answers[userAnswers[0] - 1].IsCorrect;
                }

                // Nəticəni emal edirik
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect answer!");
                    Console.ResetColor();
                    correctAnswers++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nIncorrect answer.");
                    Console.ResetColor();
                    Console.WriteLine("Correct answer(s):");
                    foreach (var answer in question.Answers.Where(a => a.IsCorrect))
                    {
                        Console.WriteLine($"- {answer.Text}");
                    }
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

            // Quizin yekun nəticəsini hesablayırıq
            var result = new Result
            {
                UserId = userId,
                QuizId = quiz.Id,
                Score = correctAnswers
            };
            if (result != null)
            {
                _database.Results.Add(result);
                Console.Clear();
                Console.WriteLine($"Quiz completed!\nYour score: {result.Score}% ({correctAnswers}/{questions.Count} correct)");
            }
            else
            {
                Console.WriteLine("Error calculating results.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            _database.SaveChanges();
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }


}
