using Fort.DTOs;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
    public class DoctorService : IDoctorService
    {   

        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly INumberVerificationService _numberVerificationService;

        public DoctorService(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IUserRepository userRepository, IRoleRepository roleRepository, INumberVerificationService numberVerificationService)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _numberVerificationService = numberVerificationService;
        }

        public async Task<BaseResponse> AddDoctor(CreateDoctorRequest Doctorrequest, int AdminId)
        {
            var a = _userRepository.GetUser(Doctorrequest.Email);

            if (a != null)
            {
                return new BaseResponse
                {
                    Message = "Doctor already exist",
                    Status = false

                };
            }
            else
            {
                var user = new User
                {
                    Email = Doctorrequest.Email,
                    PassWord = BCrypt.Net.BCrypt.HashPassword(Doctorrequest.PassWord),
                    CreatedBy = 1,
                    PhoneNumber = Doctorrequest.PhoneNumber,
                    Age = Doctorrequest.Age,
                    Gender = Doctorrequest.Gender,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    LastModifiedBy = 1,

                };
                await _numberVerificationService.VerifyMobileNumber(Doctorrequest.PhoneNumber);

                _userRepository.Add(user);

                List<string> s = new List<string> { "Doctor" };
                var roles = _roleRepository.GetSelectedUserRole(s);
                var doctor = new Doctor
                {
                    FirstName = Doctorrequest.FirstName,
                    LastName = Doctorrequest.LastName,
                    User = user,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,


                    CertificatePath = Doctorrequest.Certificate,
                    Specialization = Doctorrequest.Specialization,
                    LastModifiedBy = 1,
                    CreatedBy = 1,
                    UserId = user.Id
                };

                foreach (var role in roles)
                {
                    var userRole = new UserRole
                    {
                        CreatedOn = DateTime.Now,
                        IsDeleted = false,
                        LastModifiedBy = 1,
                        CreatedBy = 1,
                        Role = role,
                        RoleId = role.Id,
                        User = user,
                        UserId = user.Id
                    };
                    user.UserRoles.Add(userRole);
                }
                _doctorRepository.Add(doctor);

                return new BaseResponse
                {
                    Message = "Successfully added",
                    Status = true
                };
            }
        }


        








        public BaseResponse DeleteDoctor(int DoctorId)
        {
            var doctor = _doctorRepository.GetDoctor(DoctorId);
            if (doctor == null)
            {
                return new BaseResponse()
                {
                    Message = "does not exist",
                    Status = false,
                };
            }
            var user = _userRepository.GetUser(doctor.User.Id);
                   doctor.IsDeleted = true;
            _doctorRepository.Update(doctor);
            if (user== null)
             {
                return new BaseResponse()
                {
                    Message = " user does not exist",
                    Status = false,
                };
             }

         
            user.IsDeleted = true;
            _userRepository.Update(user);
            
            return new BaseResponse()
            {
                Message = "deleted successful",
                Status = true,
            };

        }






        public DoctorResponsModel GetDoctor(string email)
        {
            var doctor = _doctorRepository.GetByExpression(c=>c.User.Email==email);
            if (doctor != null)
            {
                return new DoctorResponsModel
                {
                    Data = new DoctorDto
                    {
                        Id = doctor.Id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Email = doctor.User.Email,
                        Gender=doctor.User.Gender,
                        Specialization = doctor.Specialization,
                        PhoneNumber = doctor.User.PhoneNumber,
                       

                    },
                    Message = "Successfully added",
                    Status = true


                };
            }
            return new DoctorResponsModel
            {
               
                Message = "Not found",
                Status = true
            };
        }








        public DoctorResponsModel GetDoctorById(int id)
        {
            var doctor = _doctorRepository.GetDoctor(id);
            if (doctor == null)
            {
                return new DoctorResponsModel()
                {
                    Message = "does not exist",
                    Status = false,
                };
            }
            return new DoctorResponsModel
            {
                Data = new DoctorDto
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    userRoles = doctor.User.UserRoles.Select(e => e.Role.Name).ToList(),
                    Email = doctor.User.Email,
                    Age = doctor.User.Age,
                    Gender= doctor.User.Gender,
                    Specialization = doctor.Specialization,
                    PhoneNumber = doctor.User.PhoneNumber,

                },
                Message = "succesfully get",
                Status = true

            };

        }





        public BaseResponse ApproveDoctor(int id)
        {
            var doctor = _doctorRepository.GetByExpression(c => c.Id== id);
            if (doctor == null) return new BaseResponse
            {
                Message = "Doctor does not  exsist",
                Status = false
            };
            else
            {
                doctor.ValidateDoctor = Approval.Approve;
                _doctorRepository.Update(doctor);
                return new BaseResponse
                {
                    Message = "Doctor approved",
                    Status = true
                };
            }
        }






        public BaseResponse DisapproveDoctor(int id)
        {
            var doctor = _doctorRepository.GetByExpression(c => c.Id == id);
            if (doctor == null) return new BaseResponse
            {
                Message = "Doctor does not  exsist",
                Status = false
            };
            else
            {
                doctor.ValidateDoctor = Approval.Decline;
                _doctorRepository.Update(doctor);
                return new BaseResponse
                {
                    Message = "Doctor approved",
                    Status = true
                };
            }
        }






        public DoctorsResponseModel GetDoctors()
        {
            var doctors = _doctorRepository.GetDoctors();
            if (doctors.Count==0)
            {
                return new DoctorsResponseModel
                {
                    Message = "unSuccessful",
                    Status = false,
                };
            }
            return new DoctorsResponseModel
            {
                Data = doctors.Select(doctor=>new DoctorDto
                {
                    Id = doctor.UserId,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.User.Email,
                    Age=doctor.User.Age,
                    Gender=doctor.User.Gender,
                    UserName=doctor.FirstName +" "+doctor.LastName,
                    Specialization = doctor.Specialization,
                    PhoneNumber = doctor.User.PhoneNumber,
                }).ToList(),
               
                Message = "Successful",
                Status = true


            };
        }





        public BaseResponse UpdateDoctor(UpdateDoctorRequest request, int id)
        {
            
            var user = _userRepository.GetUser(id);
            

            if (user == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Does not exist"
                };
            }
            var doctor = _doctorRepository.GetDoctor(user.Id);

            {
                var roles = _roleRepository.GetUserRole(user.Id);
                doctor.FirstName = request.FirstName;
                doctor.LastName = request.LastName;
                doctor.User.Age = request.Age;
                doctor.User = user;
                doctor.User.Email = request.EmailAddress;
                user.Email = request.EmailAddress;
                doctor.User.PhoneNumber = request.PhoneNumber;
                user.CreatedBy = user.Id;
                user.LastModifiedBy = user.Id;
           
              
                
              
            };
            _userRepository.Update(user);
            _doctorRepository.Update(doctor);
            return new BaseResponse
            {
                Message = "Updated added",
                Status = true
            };
        }
    }
}
