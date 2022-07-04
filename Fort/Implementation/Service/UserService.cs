using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Fort.Model;
using Fort.Implementation.Repository;
using Fort.Interfaces.Service;
using Fort.DTOs;

namespace Fort.Implementation.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        
        



        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public BaseResponse DeleteUser(int userId)
        {
            var  user=_userRepository.GetUser(userId);
            if (user == null)
            {
                return new BaseResponse
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            user.IsDeleted = true;
            user.DeletedOn = DateTime.Now;
            _userRepository.Update(user);
            return new BaseResponse
            {
                Message = "Deleted successful",
                Status = true
            };
        }


        public UserResponsModel GetUserById(int id)
        {
           var user=_userRepository.GetByExpression(y=>y.Id == id);
            if (user == null)
            {
                return new UserResponsModel
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            return new UserResponsModel
            {
                Data=new UserDto
                {
                   Email=user.Email,
                   PassWord=user.PassWord,
                   Roles=user.ApplicationUserRoles,
                   UserName=user.UserName
                },
                Message="get successful",
                Status=true

            };
        }




        public UsersResponseModel GetUsersByRole(string name)
        {
            var users = _userRepository.GetUsersByRole(name);
            return new UsersResponseModel
            {
                Data = users.Select(r => new UserDto
                {
                    Id=r.Id,
                    UserName=r.UserName,
                    Roles=r.ApplicationUserRoles,
                    Email=r.Email,
                    PassWord=r.PassWord,
                    
                   
                }).ToList(),
                Message = "get successful",
                Status = true
            };

        }


        public UsersResponseModel GetUsers()
        {
            var users = _userRepository.GetUsers();
            return new UsersResponseModel
            {
                Data = users.Select(r => new UserDto
                {
                    Id = r.Id,
                    UserName = r.UserName,
                    Roles = r.ApplicationUserRoles,
                    Email = r.Email,
                    PassWord = r.PassWord,


                }).ToList(),
                Message = "get successful",
                Status = true
            };

        }



        public LoginResponseModel LogIn(LoginUserRequest userrequest)
        {
           var user=_userRepository.GetByExpression(x=>x.Email==userrequest.EmailAddress && x.PassWord==userrequest.PassWord);
            if (user == null)
            {
                return new LoginResponseModel
                {
                    Message = "invalid email or password",
                    Status = false
                };
            }
            else
            {
                return new LoginResponseModel
                {

                };
               
            }
        }
    }
}
