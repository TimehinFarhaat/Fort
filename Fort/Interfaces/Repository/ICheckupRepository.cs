using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface ICheckupRepository: IBaseRepository<CheckUp>
    {
     
        public IList<CheckUp> GetcheckUps();
        public IList<PatientCheckup> GetpatientcheckUps(int patientId);





    }
}
