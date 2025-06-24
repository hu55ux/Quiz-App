using QuizGame.Entities;
using QuizGame.Helper;

namespace QuizGame.Database;

public class Database
{
    public List<User>? Users { get; set; }
    public Quiz? HistoryQuiz { get; set; }
    public Quiz? GeographyQuiz { get; set; }
    public Quiz? BiologyQuiz { get; set; }
    public Quiz? MixedQuiz { get; set; }
    public List<Result>? Results { get; set; }
    private string jsonUsers = "users.json";
    private string jsonHistoryQuiz = "historyQuiz.json";
    private string jsongeographyQuiz = "geographyQuiz.json";
    private string jsonbiologyQuiz = "biologyQuiz.json";
    private string jsonmixedQuiz = "mixedQuiz.json";
    private string jsonResults = "results.json";

    public Database()
    {
        Users = new List<User>();
        Results = new List<Result>();
        HistoryQuiz = new Quiz();
        GeographyQuiz = new Quiz();
        BiologyQuiz = new Quiz();
        MixedQuiz = new Quiz();
        var quizzes = JsonHelper.LoadListFromJson<Quiz>("quizzes.json");

        Users = JsonHelper.LoadListFromJson<User>(jsonUsers);
        HistoryQuiz = quizzes.First(q => q.Category == QuizCategory.History);
        GeographyQuiz = quizzes.First(q => q.Category == QuizCategory.Geography);
        BiologyQuiz = quizzes.First(q => q.Category == QuizCategory.Biology);
        MixedQuiz = quizzes.First(q => q.Category == QuizCategory.Mixed);
        //Results = JsonHelper.LoadListFromJson<Result>(jsonResults);
    }

    public void SaveAll()
    {
        JsonHelper.SaveToJson(Users, jsonUsers);
        JsonHelper.SaveToJson(HistoryQuiz, jsonHistoryQuiz);
        JsonHelper.SaveToJson(GeographyQuiz, jsongeographyQuiz);
        JsonHelper.SaveToJson(BiologyQuiz, jsonbiologyQuiz);
        JsonHelper.SaveToJson(MixedQuiz, jsonmixedQuiz);
        //JsonHelper.SaveToJson(Results, jsonResults);
    }



}
