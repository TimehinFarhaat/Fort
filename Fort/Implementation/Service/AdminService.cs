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
        private readonly IRoleRepository _roleRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AdminService(IUserRepository userRepository, IRoleRepository roleRepository, IAdminRepository adminRepository, IDoctorRepository doctorRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _adminRepository = adminRepository;
            _doctorRepository = doctorRepository;
        }

        public BaseResponse AddAdmin(CreateAdminRequest Adminrequest,int AdminId)
        {
            var check =_userRepository.GetByExpressions(r => r.Email == Adminrequest.EmailAddress);
            if (check == null)
            {
                var user = new User
                {
                    UserName = Adminrequest.FirstName,
                    Email = Adminrequest.EmailAddress,
                    PassWord = Adminrequest.PassWord,
                    CreatedBy = AdminId,
                };
                _userRepository.Add(user);
                var roles = _roleRepository.GetByExpression(r => r.Name == "Admin");

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
                var admin = new Admin
                {
                    FirstName = Adminrequest.FirstName,
                    LastName = Adminrequest.LastName,
                    Email = Adminrequest.EmailAddress,
                    CreatedBy = AdminId,
                    UserId = user.Id
                };

                _adminRepository.Add(admin);
                return new BaseResponse
                {
                    Message = "Successfully added",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse
                {
                    Message = "User already exsist",
                    Status = false
                };

            }

        }




        public BaseResponse ApproveDoctor(string email)
        {
            var doctor = _doctorRepository.GetByExpression(c => c.EmailAddress == email);
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






        public BaseResponse DisapproveDoctor(string email)
        {
            var doctor = _doctorRepository.GetByExpression(c => c.EmailAddress == email);
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






        public AdminResponsModel GetAdminById(int id)
        {
            var admin = _adminRepository.GetByExpression(x=>x.Id==id  &&  x.IsDeleted ==false);
            if (admin == null)
            {
                return new AdminResponsModel
                {
      
                    Message = "Get Successful",
                    Status = true

                };
            }

            return new AdminResponsModel
            {
                Data = new AdminDto
                {
                    Id = admin.Id,
                    UserName = admin.FirstName + " " + admin.LastName,
                    Email = admin.Email,
                    PassWord = admin.Password,
                },
                Message = "Get Successful",
                Status = true

            };

        }

        public AdminResponsModel GetAdminByEmail(string email)
        {
            var admin= _adminRepository.GetByExpression(x=>x.Email==email);
            if (admin == null)
            {
                return new AdminResponsModel
                {
                    Message = "unSuccessful",
                    Status = false
                };
            }
            
            return new AdminResponsModel
            {
                Data = new AdminDto
                {
                    Id = admin.Id,
                    UserName = admin.FirstName + " " + admin.LastName,
                    Email = admin.Email,
                    PassWord = admin.Password,
                },
                Message = "Get Successful",
                Status = true

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
                    Age = u.Age,
                    Email = u.Email,
                    Id = u.Id,
                    PassWord = u.Password,
                    UserName = u.FirstName + " " + u.LastName,
                    UserRoles = u.ApplicationUser.ApplicationUserRoles
                }).ToList(),

                Message = "Get Successful",
                Status = true

            };
        }




        public BaseResponse UpdateAdmin(UpdateAdminRequest request, int id)
        {
            var user = _userRepository.GetByExpression(x => x.Id == id);
                                      

            if (user == null)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Does not exist"
                };
            }

            {
                user.UserName=request.UserName;
                user.Email = request.EmailAddress;
                user.LastModifiedBy = user.Id;
                user.Id = user.Id;
            };

            _userRepository.Update(user);
            return new BaseResponse
            {
                Message = "Updated added",
                Status = true
            };
            
        }

        public BaseResponse DeleteAdmin(string email)
        {
            var admin = _adminRepository.GetByExpression(x => x.EmailAddress == email && x.IsDeleted == false);
            if (admin == null)
            {
                return new BaseResponse
                {

                    Message = "Get Successful",
                    Status = false

                };
            }
            admin.IsDeleted=true;
            _adminRepository.Update(admin);
            return new BaseResponse
            {

                Message = "Delete successful",
                Status = true

            };
        }
    }
}
