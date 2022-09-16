using Fort.DTOs;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;
using System.Linq.Expressions;

namespace Fort.Implementation.Service
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly INumberVerificationService _numberVerificationService;

        public AdminService(IUserRepository userRepository, IPatientRepository patientRepository, IAdminRepository adminRepository, IRoleRepository roleRepository, INumberVerificationService numberVerificationService)
        {
            _userRepository = userRepository;
            _patientRepository = patientRepository;
            _adminRepository = adminRepository;
            _roleRepository = roleRepository;
            _numberVerificationService = numberVerificationService;
        }

        public async Task<BaseResponse> AddAdmin(CreateAdminRequest Adminrequest)
        {
          
            var q = _userRepository.GetByExpression(s => s.Email == Adminrequest.EmailAddress);

            if (q != null)
            {
                return new BaseResponse
                {
                    Message = "Admin already exist",
                    Status = false
                };
            }
            
            
                var user = new User
                {
                    Email = Adminrequest.EmailAddress,
                    PassWord = BCrypt.Net.BCrypt.HashPassword(Adminrequest.PassWord),
                    PhoneNumber = Adminrequest.Phonenumber,
                    Age = Adminrequest.Age,
                    Gender = Adminrequest.Gender,

                };
                List<string> s = new List<string> {"Admin" }; 
                var roles = _roleRepository.GetSelectedUserRole(s);
            await _numberVerificationService.VerifyMobileNumber(Adminrequest.Phonenumber);
                        _userRepository.Add(user);
            var admin = new Admin
                {
                    DateOfBirth = DateTime.Now,
                    FirstName = Adminrequest.FirstName,
                    LastName = Adminrequest.LastName,
                    User = user,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    UserId = user.Id
                };
               
                foreach (var role in roles)
                {
                    var userRole = new UserRole
                    {
                        CreatedOn = DateTime.Now,
                        IsDeleted = false,
                        
                        Role= role,
                        RoleId=role.Id,
                        User=user,
                        UserId=user.Id
                    };
                    user.UserRoles.Add(userRole);
                }
                _adminRepository.Add(admin);
            return new BaseResponse
            {
                Message = "Successfully added",
                Status = true
            };
            
        

        }



        public AdminResponsModel GetAdminById(int id)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new AdminResponsModel
                {
      
                    Message = "Get unSuccessful",
                    Status = false,

                };
            }

            return new AdminResponsModel
            {
                Data = new AdminDto
                {
                    Id = admin.Id,
                    UserName = admin.FirstName + " " + admin.LastName,
                    Email = admin.User.Email,
                    Age = admin.User.Age,
                    Gender = admin.User.Gender,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    userRoles = admin.User.UserRoles.Select(e => e.Role.Name).ToList(),
                    DateofBirth = admin.DateOfBirth,
                    PhoneNumber = admin.User.PhoneNumber,
                    DateCreated = admin.CreatedOn
                },
                Message = "Get Successful",
                Status = true

            };

        }

        public AdminResponsModel GetAdminByEmail(string email)
        {
            var admin= _adminRepository.GetAdmin(email);
            
            if (admin != null)
            {
                return new AdminResponsModel
                {
                    Data = new AdminDto
                    {
                        Id = admin.Id,
                        UserName = admin.FirstName + " " + admin.LastName,
                        Email = admin.User.Email,
                        Age=admin.User.Age,
                        Gender = admin.User.Gender,
                        FirstName=admin.FirstName,
                        LastName=admin.LastName,
                        userRoles=admin.User.UserRoles.Select(e=>e.Role.Name).ToList(),
                        DateofBirth=admin.DateOfBirth,
                        PhoneNumber = admin.User.PhoneNumber,
                        DateCreated=admin.CreatedOn


                    },
                    Message = "Get Successful",
                    Status = true

                };
            }
            return new AdminResponsModel
            {
                Message = "unSuccessful",
                Status = false
            };


        }




        public AdminsResponseModel GetAdmins()
        {
            var admins = _adminRepository.GetAdmins();
            if (admins == null)
            {
                return new AdminsResponseModel
                {
                    Message = "unSuccessful",
                    Status = false
                };
            }
            return new AdminsResponseModel
            {
                Data = admins.Select(u => new AdminDto
                {
                    Age = u.User.Age,
                    Gender=u.User.Gender,
                    Email = u.User.Email,
                    FirstName=u.FirstName,
                    LastName=u.LastName,
                    Id = u.User.Id,
                    UserName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.User.PhoneNumber,

                }).ToList(),

                Message = "Get Successful",
                Status = true

            };
        }




        public BaseResponse UpdateAdmin(UpdateAdminRequest request, int userId)
        {
            var user = _userRepository.GetByExpression(x => x.Id == userId);
         
                                      

            if (user == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Does not exist"
                };
            }
            var admin = _adminRepository.GetAdmin(user.Id);
            {
                var roles = _roleRepository.GetUserRole(user.Id);
                admin.FirstName = request.FirstName;
                admin.LastName = request.LastName;
                admin.User.Age = request.Age;
                user.LastModifiedOn= DateTime.Now;
                admin.LastModifiedOn= DateTime.Now;
                user.Email = request.EmailAddress;
                
                user.LastModifiedBy = user.Id;
                admin.User.PhoneNumber = request.Phonenumber;
               
               
                _userRepository.Update(user);
                _adminRepository.Update(admin);
            };

           
            return new BaseResponse
            {
                Message = "Updated added",
                Status = true
            };
            
        }

        public BaseResponse DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "not found",
                    Status = false,
                };
            }
            var user = _userRepository.GetUser(admin.User.Id);
            if(user == null)
            {
                return new BaseResponse
                {
                    Message = " user not found",
                    Status = false,
                };
            }
            admin.IsDeleted = true;
            user.IsDeleted = true;
            admin.DeletedOn = DateTime.Now;

            _userRepository.Update(user);
            
            _adminRepository.Update(admin);
            return new BaseResponse
            {
                Message = "Deleted successfully",
                Status = true,
            };
        }
    }
}
