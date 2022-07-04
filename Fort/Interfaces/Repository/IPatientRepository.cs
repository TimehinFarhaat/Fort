using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IPatientRepository: IBaseRepository<Patient>
    {
      
        public IList<Patient> GetPatients();
        public Patient Getpatient(int  id);
    }
}
