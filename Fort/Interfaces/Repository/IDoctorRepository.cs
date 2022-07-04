using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IDoctorRepository:IBaseRepository<Doctor>
    {
        public IList<Doctor> GetDoctors();
        public Doctor GetDoctor(int id);
    }
}
