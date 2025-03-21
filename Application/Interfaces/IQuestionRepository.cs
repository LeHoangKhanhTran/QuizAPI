using QuizAPI.Entities;

namespace QuizAPI.Interfaces;

public interface IQuestionRepository 
{
    public Task<IEnumerable<Question>> GetQuestions(Guid? topicId);
    public Task<Question> GetQuestionById(Guid id);
    public Task CreateQuestion(Question question);
    public Task UpdateQuestion(Question question);
    public Task DeleteQuestion(Guid id);
}