using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
       
        public IList<Rating> GetRating(int id);
    }
}
