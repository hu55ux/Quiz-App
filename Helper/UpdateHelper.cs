using QuizGame.Entities;
namespace QuizGame.Helper;

public class UpdateHelper
{
    private Question _question;

    public UpdateHelper(Question question)
    {
        _question = question;
    }

    public UpdateHelper UpdateText()
    {
        Console.Write("Enter new question text (leave empty to keep current): ");
        string? newText = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newText))
        {
            _question.Text = newText;
        }
        return this;
    }

    public UpdateHelper UpdateMultipleChoice()
    {
        Console.Write(
            $"Is the question multiple choice? (current: {_question.isMultipleChoice}, enter 1 for Yes, 0 for No, leave empty to keep current): "
        );
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int choice))
        {
            if (choice == 1) _question.isMultipleChoice = true;
            else if (choice == 0) _question.isMultipleChoice = false;
        }

        return this;
    }

    public UpdateHelper UpdateAnswers()
    {
        Console.WriteLine("Current answers:");
        for (int i = 0; i < _question.Answers.Count; i++)
        {
            var answer = _question.Answers[i];
            Console.WriteLine($"{i + 1}. {answer.Text} (IsCorrect: {answer.IsCorrect})");
        }

        Console.Write("Do you want to update answers? (1 for Yes, 0 for No): ");
        string? updateAnswers = Console.ReadLine();

        if (int.TryParse(updateAnswers, out int choice) && choice == 1)
        {
            for (int i = 0; i < _question.Answers.Count; i++)
            {
                var answer = _question.Answers[i];

                Console.Write($"Enter new text for answer {i + 1} (leave empty to keep current): ");
                string? newText = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newText))
                {
                    answer.Text = newText;
                }

                Console.Write($"Is this answer correct? (current: {answer.IsCorrect}, enter 1 for Yes, 0 for No, leave empty to keep current): ");
                string? isCorrectInput = Console.ReadLine();

                if (int.TryParse(isCorrectInput, out int correctChoice))
                {
                    if (correctChoice == 1) answer.IsCorrect = true;
                    else if (correctChoice == 0) answer.IsCorrect = false;
                }
            }
        }

        return this;
    }
    public Question Build()
    {
        return _question;
    }
}
