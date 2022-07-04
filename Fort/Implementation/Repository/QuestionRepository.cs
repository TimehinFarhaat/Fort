using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;

namespace Fort.Implementation.Repository
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
