using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class PatientRepository : BaseRepository<Patient>,IPatientRepository
    {
        public PatientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public Patient GetpatientById(int id)
        {
            var patient = _context.Patients.Include(u=>u.User).ThenInclude(a=> a.UserRoles).ThenInclude(r=>r.Role).SingleOrDefault(u => u.userId == id && u.IsDeleted == false );
            return patient;
        }

        public Patient GetpatientByEmail(string email)
        {
            var patient = _context.Patients.Include(u => u.User).ThenInclude(y=>y.UserRoles).ThenInclude(r=>r.Role).SingleOrDefault(u => u.User.Email == email && u.IsDeleted == false);
            return patient;
        }




        public IList<Patient> GetPatients()
        {
            var patients = _context.Patients.Include(u => u.User).Where(o=>o.IsDeleted==false).ToList();
            return patients;
        }
    }
}
