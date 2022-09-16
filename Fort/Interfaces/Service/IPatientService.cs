using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IPatientService
    {
        public Task<BaseResponse> AddPatient(CreatePatientRequest patientRequest);
        public PatientResponsModel GetPatientByEmail(string email);
        public PatientResponsModel GetPatientById(int id);
        public BaseResponse DeletePatient(int patientId);
 
        public BaseResponse UpdatePatient(UpdatePatientRequest request, int id);
        public PatientResponseModel GetPatients();
    }
}
