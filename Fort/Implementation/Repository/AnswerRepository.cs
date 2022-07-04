using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;

namespace Fort.Implementation.Repository
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
