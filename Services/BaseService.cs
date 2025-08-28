namespace QuizGame.Services;
public class BaseService
{
    protected QuizGameDBContext _database;
    public BaseService(QuizGameDBContext database)
    {
        _database = database;
    }
}
