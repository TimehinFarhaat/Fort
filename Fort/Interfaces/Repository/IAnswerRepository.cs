using Fort.Model;
using System.Linq.Expressions;

namespace Fort.Interfaces.Repository
{
    public interface IAnswerRepository :IBaseRepository<Answer>
    {
        public IList<Answer> GetAnswersByDoctorId(int id);
        public IList<Answer> GetAnswersToQuestion(int id);
    }
}
