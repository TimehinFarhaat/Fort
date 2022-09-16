using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fort.Implementation.Repository
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public IList<Answer> GetAnswersByDoctorId(int id) 
        {
            var doctor = _context.Answers.Include(e=>e.Question).Include(r=>r.Doctor).ThenInclude(e=>e.User).Include(t=>t.Question).Where(y=>y.DoctorId==id).ToList();
            return doctor;
        }


       


        public IList<Answer> GetAnswersToQuestion(int id)
        {
            var answers = _context.Answers.Include(r => r.Doctor).ThenInclude(r=>r.User).Include(t => t.Question).Where(y => y.QuestionId == id).ToList();
            return answers;
        }
    }
}
