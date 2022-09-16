using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            
        }
        public IList<Question> GetUserQuestions(string email)
        {

            var question = _context.Questions.Include(r=>r.Patient).ThenInclude(y=>y.User).Include(r=>r.Answers).Include(c => c.Answers).ThenInclude(t => t.Doctor).Where(x => x.Patient.User.Email == email && x.IsDeleted == false).ToList();
            return question;
        }

        public IList<Question> GetQuestions()
        {

            var question = _context.Questions.Include(e=>e.Answers).ThenInclude(r=>r.Doctor).Include(r=>r.Answers).Where(x => x.IsDeleted == false).ToList();
            return question;
        }
        public Question GetQuestionById(int id)
        {

            var question = _context.Questions.Include(r => r.Patient).ThenInclude(t=>t.User).Include(y=>y.Answers).ThenInclude(t=>t.Doctor).SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return question;
        }
    }
}

