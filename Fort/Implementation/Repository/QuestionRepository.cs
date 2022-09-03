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

            var question = _context.Questions.Include(r=>r.User).Include(r=>r.Answers).ThenInclude(c => c.Ratings).Include(c => c.Answers).ThenInclude(t => t.Doctor).Where(x => x.User.Email == email && x.IsDeleted == false).ToList();
            return question;
        }

        public IList<Question> GetQuestions()
        {

            var question = _context.Questions.Include(e=>e.Answers).ThenInclude(r=>r.Doctor).Include(r=>r.Answers).ThenInclude(e=>e.Ratings).Where(x => x.IsDeleted == false).ToList();
            return question;
        }
        public Question GetQuestionById(int id)
        {

            var question = _context.Questions.Include(r => r.User).Include(y=>y.Answers).ThenInclude(t=>t.Doctor).SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return question;
        }
    }
}

