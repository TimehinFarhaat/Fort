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
        private readonly IPatientCheckupRepository _patientcheckupRepository;
        private readonly ISymptomRepository _symptomRepository;
        private readonly ISymptomCheckupRepository _symptomCheckupRepository;
        private readonly IUserRepository _userRepository;






        public CheckupService(ICheckupRepository checkupRepository, IPatientRepository patientRepository, IPatientCheckupRepository patientcheckupRepository, ISymptomRepository symptomRepository, ISymptomCheckupRepository symptomCheckupRepository,IUserRepository userRepository)
        {
            _checkupRepository = checkupRepository;
            _patientRepository = patientRepository;
            _patientcheckupRepository = patientcheckupRepository;
            _symptomRepository = symptomRepository;
             _symptomCheckupRepository = symptomCheckupRepository;
            _userRepository=userRepository;
        }





        public BaseResponse CreateCheckup(CreateCheckupRequest checkrequest,int patientId )
        {
            var patient=_patientcheckupRepository.GetPatientByUserId(patientId);
           if(patient== null)
            {
                return new BaseResponse
                {
                    Message = "patient not found",
                    Status = false
                };
            }
            var check = new CheckUp
            {
                Description = checkrequest.Description,
                Name = checkrequest.Name,
            };

            _checkupRepository.Add(check);

            foreach (var sympton in checkrequest.Symptoms)
            {
                var exist = _symptomRepository.GetSymptom(sympton);
                if (exist == null)
                {
                    var symptom = new Symptom()
                    {
                        Name = sympton,
                        CreatedBy = patient.UserId,

                    };
                    _symptomRepository.Add(symptom);
                    var symptomchecks = new SymptomCheckup()
                    {
                        Checkup = check,
                        CheckUpId = check.Id,
                        Symptom = symptom,
                        SymptomId = symptom.Id

                    };
                    _symptomCheckupRepository.Add(symptomchecks);
                }
                else
                {
                    var symptomcheck = new SymptomCheckup()
                    {
                        Checkup = check,
                        CheckUpId = check.Id,
                        Symptom = exist,
                        SymptomId = exist.Id,

                    };
                    _symptomCheckupRepository.Add(symptomcheck);
                }
            }

            var checkup = new PatientCheckup
            {
                CreatedBy = patientId,
                Checkup = check,
                CheckUpId = check.Id,
                Patient = patient,
                LastModifiedBy = patient.Id,
                PatientId = patient.Id,
              CreatedOn=DateTime.Now,
            };

            _patientcheckupRepository.Add(checkup);

            return new BaseResponse
            {
                Message = " checkUp Successfully created",
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
            var patient = _patientRepository.GetByExpression(r => r.UserId == patientId);
            var checks = _checkupRepository.GetpatientcheckUps(patient.Id);
            if(checks.Count > 0)
            {
                var check=checks[checks.Count-1];
                return new CheckupResponseModel
                {
                    Data = new CheckupDto
                    {

                        Id = check.Checkup.Id,
                        Description = check.Checkup.Description,
                        Name = check.Checkup.Name,
                        DateTime=check.CreatedOn,

                        SymptomDto = check.Checkup.SymptomCheckups.Select(i => new SymptomDto
                        {
                            SymptomName = i.Symptom.Name,
                            SymptomId = i.Symptom.Id,
                        }).ToList(),
                    },
                    Message = "get successful",
                    Status = true
                };
            }

            return new CheckupResponseModel
            {
                
                Message = "No checkup record",
                Status = true
            };
        }




        public CheckupResponseModels GetCheckUpByPatientId(int patientId)
        {
            var patient1= _patientRepository.GetpatientById(patientId);

            if (patient1 == null)
            {
                return new CheckupResponseModels
                {
                    Message = "Patient not available",
                    Status = false
                };
            }
            var patientCheckup= _checkupRepository.GetpatientcheckUps(patient1.Id);


            return new CheckupResponseModels
            {
                Data = patientCheckup.Select(check => new CheckupDto
                {
                    Id = check.Id,
                    Description = check.Checkup.Description,
                    Name = check.Checkup.Name,
                    DateTime = check.Checkup.CreatedOn,

                    SymptomDto = check.Checkup.SymptomCheckups.Select(c => new SymptomDto
                    {
                        SymptomId = c.SymptomId,
                        SymptomName = c.Symptom.Name,
                    }).ToList(),

                }).ToList(),

                    Message = "Get checkup successful",
                    Status = true
            };
            
        }




       

       
    }
}
