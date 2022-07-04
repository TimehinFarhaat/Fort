using Fort.Context;
using Fort.Interfaces.Repository;
using Fort.Model;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public Doctor GetDoctor(int id)
        {
            var doctor = _context.Doctors.Include(u => u.ApplicationUser).FirstOrDefault(u => u.Id == id&& u.ValidateDoctor== Approval.Approve&&u.IsDeleted==false);
            return doctor;
        }

        public IList<Doctor> GetDoctors()
        {
            var doctors = _context.Doctors.Include(u => u.ApplicationUser).Where(u => u.ValidateDoctor == Approval.Approve && u.IsDeleted==false).ToList();
            return doctors;
        }
    }
}
