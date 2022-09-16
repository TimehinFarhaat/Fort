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
        private readonly INumberVerificationService _numberVerificationService;
        private readonly IMailService _mailService;


        public PatientService(IUserRepository userRepository, IPatientRepository patientRepository, IRoleRepository roleRepository, INumberVerificationService numberVerificationService,IMailService mailService)
        {
            _userRepository = userRepository ;
            _patientRepository = patientRepository ;
             _roleRepository = roleRepository ; 
            _numberVerificationService = numberVerificationService;
            _mailService = mailService ;

        }

        public async Task<BaseResponse> AddPatient(CreatePatientRequest patientRequest)
        {

            var checkUser = _userRepository.GetUser(patientRequest.EmailAddress);

            if (checkUser != null)
            {
                return new BaseResponse
                {
                    Message = "Patient already exist",
                    Status = false
                };
            }

                var user = new User
                {
                    Email = patientRequest.EmailAddress,
                    PassWord = BCrypt.Net.BCrypt.HashPassword(patientRequest.PassWord),
                    PhoneNumber = patientRequest.PhoneNumber,
                    Age = patientRequest.Age,
                    Gender = patientRequest.Gender,
                };

              var response = await _numberVerificationService.VerifyMobileNumber(patientRequest.PhoneNumber);
            if (!response.Status) return new BaseResponse
            {
                Message = "Invalid phone number",
                Status = false
            };

            var mailrequest = new MailRequest
            {
                ToEmail = patientRequest.EmailAddress,
                ToName = patientRequest.FirstName + " " + patientRequest.LastName,
                HtmlContent = "<html><body><div><h1> Welcome to FORT</h1><div><h3>Your online medical hub,you have the access to all services including:Search forhealth issues,view diagnostic results, ask questions pertining ypur health, and get to view answers on them by our seasoned doctors.</h3><h5>FORT!-</h5><h6>Fortifying Our Health Rightly Through Technology</h6></div></div>></body></html>"
            };
            //_mailService.SendEmail(mailrequest);
            _userRepository.Add(user);

            List<string> r=   new List<string> {"patient" };

            var roles = _roleRepository.GetSelectedUserRole(r);

            var patient = new Patient
            {
                DateOfBirth = DateTime.Now,
                FirstName = patientRequest.FirstName,
                LastName = patientRequest.LastName,
                User = user,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                LastModifiedBy = user.Id,
                CreatedBy = user.Id,
                UserId = user.Id
            };
            foreach (var role in roles)
            {
                var userRole = new UserRole
                {
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    LastModifiedBy = user.Id,
                    CreatedBy = user.Id,
                    Role = role,
                    RoleId = role.Id,
                    User = user,
                    UserId = user.Id
                };
                user.UserRoles.Add(userRole);
            }
            
            _userRepository.Update(user);

            _patientRepository.Add(patient);
            return new BaseResponse
            {
                Message = "Successful",
                Status = true
            };

        }



        public BaseResponse DeletePatient(int patientId)
        {
            //var patient = _patientRepository.GetpatientById(patientId);
            //if (patient == null)
            //{
            //    return new BaseResponse
            //    {
            //        Message = "not found",
            //        Status = false,
            //    };
            //}
            var user = _userRepository.GetUser(patientId);
            if (user != null)
            {
                user.IsDeleted = true;
                user.DeletedOn= DateTime.Now;
                //patient.IsDeleted = true;
                //patient.DeletedOn = DateTime.Now;
            }
            else
            {
                return new BaseResponse
                {
                    Message = " user not found",
                    Status = false,
                };

            }

            _userRepository.Update(user);
            //_patientRepository.Update(patient);
            return new BaseResponse
            {
                Message = "Deleted successfully",
                Status = true,
            };
        }




        public PatientResponsModel GetPatientById(int id)
        {
            var patient = _patientRepository.GetpatientById(id);
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
                    Id = patient.Id,
                    UserName = patient.FirstName + " " + patient.LastName,
                    Email = patient.User.Email,
                    Age = patient.User.Age,
                    Gender = patient.User.Gender,
                    FirstName = patient.FirstName,
                    UserId = patient.UserId,
                    LastName = patient.LastName,
                    userRoles = patient.User.UserRoles.Select(e => e.Role.Name).ToList(),
                    DateofBirth = patient.DateOfBirth,
                    PhoneNumber = patient.User.PhoneNumber,
                    DateCreated = patient.CreatedOn


                },
                Message = "Successfully get",
                Status = true
            };
        }





        public PatientResponsModel GetPatientByEmail(string email)
        {
            var patient = _patientRepository.GetpatientByEmail(email);


            if (patient == null)
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
                    Id = patient.Id,
                    UserName = patient.FirstName + " " + patient.LastName,
                    Email = patient.User.Email,
                    Age = patient.User.Age,
                    Gender = patient.User.Gender,
                    FirstName = patient.FirstName,
                    UserId = patient.UserId,
                    LastName = patient.LastName,
                    userRoles = patient.User.UserRoles.Select(e => e.Role.Name).ToList(),
                    DateofBirth = patient.DateOfBirth,
                    PhoneNumber = patient.User.PhoneNumber,
                    DateCreated = patient.CreatedOn

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
                    Email = patient.User.Email,
                    Id=patient.Id,
                    UserName = patient.FirstName +"  "+ patient.LastName,
                    Gender= patient.User.Gender,
                    Age = patient.User.Age,
                    LastName = patient.LastName,
                    UserId = patient.UserId,
                    PhoneNumber = patient.User.PhoneNumber,

                }).ToList(),
                Message = "Successfully added",
                Status = true
            };
        } 

        public BaseResponse UpdatePatient(UpdatePatientRequest request, int id)
        {
            var patient = _patientRepository.GetpatientById(id);
        
            if (patient == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Does not exist"
                };
            }

            var user = _userRepository.GetUser(patient.User.Id);

            var roles = _roleRepository.GetUserRole(patient.User.Id);
            patient.FirstName = request.FirstName;
            patient.LastName = request.LastName;
            patient.User.Age = request.Age;
            user.CreatedOn = DateTime.Now;
            user.Email = request.EmailAddress;
            user.LastModifiedBy = id;
            patient.User.PhoneNumber = request.PhoneNumber;
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
