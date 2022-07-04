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
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _doctorRepository = doctorRepository ;
            _userRepository = userRepository ;
            _roleRepository = roleRepository ;
        }

        public BaseResponse AddDoctor(CreateDoctorRequest Doctorrequest, int AdminId)
        {
            var user = new User
            {
                UserName = Doctorrequest.FirstName,
                Email = Doctorrequest.Email,
                PassWord = Doctorrequest.PassWord,
                CreatedBy = AdminId,
            };
            _userRepository.Add(user);
            var roles = _roleRepository.GetByExpression(r => r.Name == "Doctor");

            var userRole = new User_role
            {
                ApplicationUserId = user.Id,
                User = user,
                ApplicationRoleId = roles.Id,
                Role = roles,
                CreatedBy = AdminId
            };

            user.ApplicationUserRoles.Add(userRole);


            _userRepository.Add(user);
            var doctor = new Doctor
            {
                FirstName = Doctorrequest.FirstName,
                LastName = Doctorrequest.LastName,
                EmailAddress = Doctorrequest.Email,
                CreatedBy = AdminId,
                Age = Doctorrequest.Age,
                Year = Doctorrequest.year,
                UserId = user.Id
            };

            _doctorRepository.Add(doctor);
            return new BaseResponse
            {
                Message = "Successfully added",
                Status = true
            };
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
            doctor.IsDeleted = true;
            _doctorRepository.Update(doctor);
            return new BaseResponse()
            {
                Message = "deleted successful",
                Status = true,
            };

        }



        public DoctorResponsModel GetDoctor(string email)
        {
            var doctor = _doctorRepository.GetByExpression(c=>c.EmailAddress==email);
            if (doctor != null)
            {
                return new DoctorResponsModel
                {
                    Data = new DoctorDto
                    {
                        Id = doctor.Id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Email = doctor.EmailAddress,
                        Specialization = doctor.Specialization

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
                    Email = doctor.EmailAddress,
                    Specialization = doctor.Specialization

                },
                Message = "succesfully get",
                Status = true

            };

        }


        public DoctorsResponseModel GetDoctors()
        {
            var doctors = _doctorRepository.GetDoctors();
            return new DoctorsResponseModel
            {
                Data = doctors.Select(doctor=>new DoctorDto
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.EmailAddress,
                    Specialization = doctor.Specialization
                }).ToList(),
               
                Message = "Successfully added",
                Status = true


            };
        }

        public BaseResponse UpdateDoctor(UpdateDoctorRequest request, int id)
        {
            var doctor = _doctorRepository.GetDoctor(id);
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
                doctor.Age = request.Age;
                doctor.ApplicationUser = user;
                doctor.EmailAddress = request.EmailAddress;
                doctor.LastModifiedBy = user.Id;
                doctor.Id = user.Id;
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
