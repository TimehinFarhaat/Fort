using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class PatientCheckupRepository : BaseRepository<PatientCheckup>, IPatientCheckupRepository
    {
        public PatientCheckupRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public Patient GetPatientByUserId(int userId)
        {
            var patient = _context.Patients.Where(u=>u.User.Id == userId).FirstOrDefault();
            return patient;

        }
    }
}