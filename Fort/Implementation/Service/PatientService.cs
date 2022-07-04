using Fort.DTOs;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
    public class PatientService : IPatientService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IRoleRepository _roleRepository;

        public PatientService(IUserRepository userRepository, IPatientRepository patientRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository ;
            _patientRepository = patientRepository ;
            _roleRepository = roleRepository ;
        }

        public BaseResponse AddPatient(CreatePatientRequest patientRequest)
        {
            if(patientRequest == null)
            {
                return new BaseResponse
                {
                    Message = "Invalid input",
                    Status = false,
                };
            }
           
           


            var s = _userRepository.GetByExpression(s => s.UserName == patientRequest.FirstName);

            if (s != null)
            {
                return new BaseResponse
                {
                    Message = "UnSuccessfully added",
                    Status = false
                };
            }


            var user = new User
            {
                UserName = patientRequest.FirstName,
                Email = patientRequest.EmailAddress,
                PassWord = patientRequest.PassWord,
                

            };
            
            _userRepository.Add(user);
            var roles = _roleRepository.GetByExpression(r => r.Name == "Patients");

            var userRole = new User_role
            {
                ApplicationUserId = user.Id,
                User = user,
                ApplicationRoleId = roles.Id,
                Role = roles,
                CreatedOn=DateTime.Now,
            };

            user.ApplicationUserRoles.Add(userRole);

            
            
            var patient = new Patient
            {
                FirstName = patientRequest.FirstName,
                LastName = patientRequest.LastName,
                EmailAddress = patientRequest.EmailAddress,
                Age = patientRequest.Age,
                ApplicationUser = user,
                ApplicationuserId = user.Id,
                CreatedOn = DateTime.Now,
                CreatedBy = user.Id,
                IsDeleted=false,
               
            };

            _patientRepository.Add(patient);
            return new BaseResponse
            {
                Message = "Successfully added",
                Status = true
            };
        }



        public BaseResponse DeletePatient(int patientId)
        {
            var patient = _patientRepository.Getpatient(patientId);
            if (patient == null)
            {
                return new BaseResponse
                {
                    Message = "not found",
                    Status = false,
                };
            }
            patient.IsDeleted = true;
            patient.DeletedOn = DateTime.Now;
            
            _patientRepository.Update(patient);
            return new BaseResponse
            {
                Message = "Deleted successfully",
                Status = true,
            };
        }




        public PatientResponsModel GetPatientById(int id)
        {
            var patient = _patientRepository.Getpatient(id);
            if (patient== null)
            {
                return new PatientResponsModel
                {
                    Message = "not found",
                    Status = false,
                };
            }
            return new PatientResponsModel
            {
                Data = new PatientDto
                {
                    Email = patient.EmailAddress,
                    FirstName = patient.FirstName,
                    Id = patient.Id,
                    LastName = patient.LastName,
                    PassWord = patient.ApplicationUser.PassWord,

                },
                Message = "Successfully get",
                Status = true
            };
        }

        public PatientResponseModel GetPatients()
        {
            var patients = _patientRepository.GetPatients();
            return new PatientResponseModel
            {
                Data = patients.Select(patient => new PatientDto
                {
                    Email = patient.EmailAddress,
                    FirstName = patient.FirstName,
                    Id = patient.Id,
                    LastName = patient.LastName,
                    PassWord = patient.ApplicationUser.PassWord,

                }).ToList(),
                Message = "Successfully added",
                Status = true
            };
        }

        public BaseResponse UpdatePatient(UpdatePatientRequest request, int id)
        {
            var patient = _patientRepository.Getpatient(id);
            var user = _userRepository.GetUser(id);

            if (user == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Does not exist"
                };
            }

            {
                patient.Age = request.Age;
                patient.ApplicationUser = user;
                patient.EmailAddress = request.EmailAddress;
                patient.LastModifiedBy = user.Id;
                patient.LastModifiedOn = DateTime.Now;
                patient.ApplicationuserId = user.Id;

                patient.Id = user.Id;
            };

            _userRepository.Update(user);
            _patientRepository.Update(patient);
            return new BaseResponse
            {
                Message = "Updated successful",
                Status = true
            };
        }
    }
}
