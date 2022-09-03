using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;

namespace Fort.Implementation.Repository
{
    public class SymptomCheckupRepository : BaseRepository<SymptomCheckup>, ISymptomCheckupRepository
    {
        public SymptomCheckupRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

      
    }
}
