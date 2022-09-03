using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class RatingRepository :BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public IList<Rating> GetRating(int id)
        {
           var ratings=_context.Ratings.Include(s=>s.Answer).Where(r => r.AnswerId == id).ToList();
            return ratings;
        }
    }
}
