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



   

       
         public IList<CheckUp> GetcheckUps()
        {
            var checks = _context.CheckUps.Include(a => a.PatientCheckups).ThenInclude(c => c.Patient).Include(i => i.SymptomCheckups).ThenInclude(s => s.Symptom).ToList();

            return checks;
        }

        public IList<PatientCheckup> GetpatientcheckUps(int patientId)
        {

            var check = _context.PatientCheckups.Include(a => a.Patient).Include(c => c.Checkup).ThenInclude(i => i.SymptomCheckups).ThenInclude(s => s.Symptom).OrderByDescending(t => t.CreatedOn).ToList();
            var c = check.Where(u => u.PatientId == patientId && u.IsDeleted == false).ToList();
            return c;
        }
    }
}
