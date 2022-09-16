using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class SymptomRepository : BaseRepository<Symptom>,ISymptomRepository
    {
       
        public SymptomRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Symptom GetSymptom(string name)
        {
            var rol = _context.Symptoms.Include(x => x.SymptomCheckups).FirstOrDefault(y=>y.Name == name);
            return rol;
        }

    }
}
