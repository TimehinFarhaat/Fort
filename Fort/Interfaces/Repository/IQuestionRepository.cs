using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        public IList<Question> GetUserQuestions(string email);
        public Question GetQuestionById(int id);
        public IList<Question> GetQuestions();
    }
}
