using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IViewRepository:IBaseRepository<View>
    {
        public IList<View> GetByUserId(int userId);
       
    }
}
