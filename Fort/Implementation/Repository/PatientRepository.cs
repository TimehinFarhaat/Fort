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
        public Patient Getpatient(int id)
        {
            var patient = _context.Patients.Include(u => u.ApplicationUser).FirstOrDefault(u => u.Id == id && u.IsDeleted == false );
            return patient;
        }

        


        public IList<Patient> GetPatients()
        {
            var patients = _context.Patients.Include(u => u.ApplicationUser).Where(o=>o.IsDeleted==false).ToList();
            return patients;
        }
    }
}
