using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IPatientRepository: IBaseRepository<Patient>
    {
        public Patient GetpatientByEmail(string email);
        public IList<Patient> GetPatients();
        public Patient GetpatientById(int  id);
    }
}
