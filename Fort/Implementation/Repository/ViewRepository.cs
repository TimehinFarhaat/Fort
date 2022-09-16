using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class ViewRepository : BaseRepository<View>, IViewRepository
    {
        public ViewRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<View> GetByUserId(int userId)
        {
          var  views = _context.Views.Include(s=>s.Question).ThenInclude(r=>r.Answers).Where(t => t.UserId == userId).ToList();
            return views;
        }
    }
}
