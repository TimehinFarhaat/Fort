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
            var doctor = _context.Doctors.Include(u => u.User).ThenInclude(e=>e.UserRoles).ThenInclude(e=>e.Role).FirstOrDefault(u => u.User.Id== id&& u.IsDeleted==false);
            return doctor;
        }

        public IList<Doctor> GetDoctors()
        {
            var doctors = _context.Doctors.Include(u => u.User).Where(u => u.ValidateDoctor == Approval.Approve && u.IsDeleted==false).ToList();
            return doctors;
        }
    }
}
