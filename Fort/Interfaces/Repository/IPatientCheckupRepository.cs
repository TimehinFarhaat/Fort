using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface  IPatientCheckupRepository : IBaseRepository<PatientCheckup>
    {
       public Patient GetPatientByUserId(int userId);
    }
}
