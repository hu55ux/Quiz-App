//using Microsoft.EntityFrameworkCore;
//using QuizGame.Entities;
//using QuizGame.Helper;
//using QuizGame.Services.Abstract;
//namespace QuizGame.Services;

//public class QuizService : BaseService, IQuizService
//{
//    public QuizService(QuizGameDBContext database) : base(database)
//    {
//    }


//    public List<Question> GetQuestions(Quiz quiz, bool random = false)
//    {
//        var questions = quiz?.Questions;

//        if (questions == null || !questions.Any())
//        {
//            return new List<Question>();
//        }
//        if (random)
//        {
//            Random randomizer = new Random();
//            questions = questions.OrderBy(q => randomizer.Next()).ToList();
//        }
//        return questions.Take(20).ToList();
//    }

//    public Quiz? GetQuizByCategory()
//    {
//        string? quizCategory = Display.SelectionCategoryForQuiz();
//        var quiz = _database.Quizzes.Include(q => q.Questions).ThenInclude(a => a.Answers).FirstOrDefault(q => q.Category.ToString() == quizCategory);
//        return quiz;
//    }

//    public List<string> GetQuizCategories()
//    {
//        var categories = new List<string>
//        {
//            QuizCategory.History.ToString(),
//            QuizCategory.Geography.ToString(),
//            QuizCategory.Biology.ToString(),
//            QuizCategory.Mixed.ToString()
//        };
//        return categories;
//    }



//    public List<Result> GetResultsByUserId(int userId)
//    {
//        var result = _database?.Results.Include(r => r.Quiz).ThenInclude(q => q.Questions).Where(r => r.UserId == userId).ToList();
//        return result;
//    }

//    public Result? ResultQuiz(string category, string userId)
//    {
//        Quiz? quiz = GetQuizByCategory(category);
//        User? user = _database?.Users?.FirstOrDefault(u => u.Id == userId);
//        Result resultQuiz = new Result
//        {
//            QuizId = quiz?.Id ?? string.Empty,
//            UserId = user?.Id ?? string.Empty,
//            UserName = user?.Username ?? string.Empty,
//            Score = quiz?.CorrectAnswersCount ?? 0,
//        };

//        return resultQuiz;
//    }

//    public void SendResults(Result result)
//    {
//        _database?.Results?.Add(result);
//    }

//    public void StartQuiz(string category, string userId)
//    {
//        try
//        {
//            // Quiz-i verilən kateqoriyaya görə yükləyirik
//            var quiz = GetQuizByCategory(category);
//            if (quiz == null)
//            {
//                Console.WriteLine($"No quiz found for category: {category}");
//                return;
//            }

//            // Sualları qarışdıraraq yükləyirik
//            var questions = GetQuestions(quiz, random: true);
//            if (questions == null || !questions.Any())
//            {
//                Console.WriteLine("No questions available for this quiz.");
//                return;
//            }

//            int correctAnswers = 0;

//            // Hər bir sual üçün dövr edirik
//            foreach (var question in questions)
//            {
//                Console.Clear();
//                Console.WriteLine($"Category: {quiz.Category}");
//                Console.WriteLine($"\nQuestion: {question.Text}\n");

//                // Seçimləri göstəririk
//                Console.WriteLine("Options:");
//                for (int i = 0; i < question.Options.Count; i++)
//                {
//                    Console.WriteLine($"{i + 1}. {question.Options[i]}");
//                }

//                // İstifadəçi cavabını alırıq və yoxlayırıq
//                List<string> userAnswers;
//                while (true)
//                {
//                    Console.Write($"\nYour answer {(question.isMultipleChoice ? "(comma separated numbers 1-4)" : "(single number)")}: ");
//                    var input = Console.ReadLine()?.Trim();

//                    // Boş daxil etməni yoxlayırıq
//                    if (string.IsNullOrEmpty(input))
//                    {
//                        Console.WriteLine("Invalid input. Please try again.");
//                        continue;
//                    }

//                    // Cavabları vergüllə ayıraraq listə çeviririk
//                    userAnswers = input.Split(',')
//                        .Select(a => a.Trim())
//                        .Where(a => !string.IsNullOrEmpty(a))
//                        .ToList();

//                    // Cavabların rəqəm olduğunu və etibarlı aralıqda olduğunu yoxlayırıq
//                    if (userAnswers.All(a => int.TryParse(a, out int num) && num >= 1 && num <= question.Options.Count))
//                    {
//                        break;
//                    }

//                    Console.WriteLine($"Please enter numbers between 1 and {question.Options.Count}");
//                }

//                // Cavabın düzgün olub olmadığını yoxlayırıq
//                bool isCorrect;
//                if (question.isMultipleChoice)
//                {
//                    // Çox seçimli suallar üçün yoxlama
//                    var correctNumbers = question.CorrectAnswers
//                        .Select(a => (question.Options.IndexOf(a) + 1).ToString());

//                    isCorrect = userAnswers.Count == question.CorrectAnswers.Count &&
//                               userAnswers.All(a => correctNumbers.Contains(a));
//                }
//                else
//                {
//                    // Tək cavablı suallar üçün yoxlama
//                    isCorrect = userAnswers.Count == 1 &&
//                               question.CorrectAnswers.Contains(question.Options[int.Parse(userAnswers[0]) - 1]);
//                }

//                // Nəticəni emal edirik
//                if (isCorrect)
//                {
//                    correctAnswers++;
//                    CorrectAnswer(quiz);
//                    Console.WriteLine("\nCorrect answer!");
//                }
//                else
//                {
//                    Console.WriteLine("\nIncorrect answer.");
//                    Console.WriteLine("Correct answer(s): " +
//                        string.Join(", ", question.CorrectAnswers));
//                }

//                Console.WriteLine("\nPress any key to continue...");
//                Console.ReadKey();
//            }

//            // Quizin yekun nəticəsini hesablayırıq
//            var result = ResultQuiz(category, userId);
//            if (result != null)
//            {
//                SendResults(result);
//                Console.Clear();
//                Console.WriteLine($"Quiz completed!\nYour score: {result.Score}% ({correctAnswers}/{questions.Count} correct)");
//            }
//            else
//            {
//                Console.WriteLine("Error calculating results.");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"An error occurred: {ex.Message}");
//        }
//        finally
//        {
//            Console.WriteLine("\nPress any key to return to menu...");
//            Console.ReadKey();
//        }
//    }

//    public List<Result> GetResultByCategory(string category)
//    {

//    }
//}
