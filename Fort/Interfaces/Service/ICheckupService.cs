using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface ICheckupService
    {
        public BaseResponse CreateCheckup(CreateCheckupRequest checkrequest,int PatientId);
        public CheckupResponseModels GetCheckUpByPatientId(int patientId);
        public CheckupResponseModel GetPreviouscheckup(int patientId);
        public BaseResponse DeleteCheckup(int checkupId);
       
    }
}
