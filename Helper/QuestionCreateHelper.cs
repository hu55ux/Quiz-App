using QuizGame.Entities;

namespace QuizGame.Helper;

public class QuestionCreateHelper
{
    private Question _question = new Question();

    public QuestionCreateHelper SetText()
    {
        while (true)
        {
            Console.Write("Enter question text: ");
            string? text = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(text))
            {
                _question.Text = text;
                break;
            }
            Console.WriteLine("Question text cannot be empty. Please try again.");
        }
        return this;
    }

    public QuestionCreateHelper SetOptions()
    {
        while (true)
        {
            Console.Write("Enter options (comma-separated): ");
            string? optionsInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(optionsInput))
            {
                var options = optionsInput
                    .Split(',')
                    .Select(o => o.Trim())
                    .Where(o => !string.IsNullOrWhiteSpace(o))
                    .ToList();

                if (options.Count >= 2)
                {
                    _question.Answers = options.Select(o => new Answer { Text = o }).ToList();
                    break;
                }
            }
            Console.WriteLine("At least two options are required. Please try again.");
        }
        return this;
    }

    public QuestionCreateHelper SetCorrectAnswers()
    {
        while (true)
        {
            Console.Write("Enter correct answers (comma-separated): ");
            string? correctInput = Console.ReadLine();
            var correctAnswers = correctInput?.Split(',')
                .Select(o => o.Trim())
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .ToList() ?? new List<string>();

            if (correctAnswers.Count == 0)
            {
                Console.WriteLine("At least one correct answer is required.");
                continue;
            }

            if (correctAnswers.All(ans => _question.Answers.Any(a => a.Text == ans)))
            {
                foreach (var ans in _question.Answers)
                {
                    ans.IsCorrect = correctAnswers.Contains(ans.Text);
                }

                _question.isMultipleChoice = correctAnswers.Count > 1;
                break;
            }

            Console.WriteLine("All correct answers must exist in the options list.");
        }
        return this;
    }

    public Question Build()
    {
        Console.WriteLine("Question created successfully.");
        return _question;
    }
}
