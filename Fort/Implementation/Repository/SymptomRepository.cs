using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;

namespace Fort.Implementation.Repository
{
    public class SymptomRepository : BaseRepository<Symptom>,ISymptomRepository
    {
       
        public SymptomRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

       
    }
}
