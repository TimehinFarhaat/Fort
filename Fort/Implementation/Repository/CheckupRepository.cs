using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class CheckupRepository : BaseRepository<CheckUp>, ICheckupRepository
    {
        public CheckupRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        

        public CheckUp GetPreviouscheckUp(int patientId)
        {
            var check = _context.checkUps.Include(a => a.PatientCheckups).ThenInclude(c => c.Patient).Include(i=>i.SymptomCheckups).ThenInclude(s=>s.Symptom).OrderByDescending(t=>t.CreatedOn).FirstOrDefault(o => o.Id == patientId && o.IsDeleted == false);
            return check; 
        }

     
    }
}
