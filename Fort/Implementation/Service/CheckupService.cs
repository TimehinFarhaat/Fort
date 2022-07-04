using Fort.DTOs;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
    public class CheckupService : ICheckupService
    {
        private readonly ICheckupRepository _checkupRepository;
        private readonly IPatientRepository _patientRepository;






        public CheckupService(ICheckupRepository checkupRepository, IPatientRepository patientRepository)
        {
            _checkupRepository = checkupRepository;
            _patientRepository = patientRepository;
        }





        public BaseResponse CreateCheckup(CreateCheckupRequest checkrequest,int patientId )
        {
            var check = new CheckUp
            {
                CreatedBy=patientId,
                Description=checkrequest.Description,
                Name=checkrequest.Name,
              
                
            };
             _checkupRepository.Add(check);
            return new BaseResponse
            {
                Message = "Successfully created",
                Status = true
            };
        }


        public BaseResponse DeleteCheckup(int checkupId)
        {
            var checkup = _checkupRepository.GetByExpression(c=>c.Id==checkupId);
            if(checkup != null)
            {
                checkup.IsDeleted = true;
                _checkupRepository.Update(checkup);
                return new BaseResponse
                {
                    Message = "Deleted succesful",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "not found",
                Status = false
            };
        }


        public CheckupResponseModel GetPreviouscheckup(int patientId)
        {
            var check = _checkupRepository.GetPreviouscheckUp(patientId);
            return new CheckupResponseModel
            {
                Data = new CheckupDto
                {

                    Id = check.Id,
                    Description = check.Description,
                    Name = check.Name,
                    Symptoms = check.SymptomCheckups.Select(i => new SymptomDto
                    {
                        SymptomName=i.Symptom.Name,
                        SymptomId=i.Symptom.Id,
                    }).ToList(),
                },
                Message = "get successful",
                Status = true
            };
        }




        public CheckupResponseModels GetCheckUpByPatientId(int patientId)
        {
            var patient = _patientRepository.Getpatient(patientId);

            return new CheckupResponseModels
            {
                Data = patient.PatientCheckup.Select(check => new CheckupDto
                {
                    Id = check.Id,
                    Description = check.Checkup.Description,
                    Name = check.Checkup.Name,

                    Symptoms = check.Checkup.SymptomCheckups.Select(c => new SymptomDto
                    {
                        SymptomId = c.SymptomId,
                        SymptomName = c.Symptom.Name,
                    }).ToList(),

                }).ToList(),

                    Message = "get successful",
                    Status = true
                };
            
        }




       

       
    }
}
