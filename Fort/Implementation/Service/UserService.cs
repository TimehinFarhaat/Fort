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
        private readonly IRoleRepository _roleRepository;
        private readonly IQuestionRepository _questionRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IQuestionRepository questionRepository)
        {
            _userRepository = userRepository ;
            _roleRepository = roleRepository;
            _questionRepository = questionRepository;
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
           var user=_userRepository.GetByExpression(y=>y.Id== id);
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
                    Id=user.Id,
                   Email=user.Email,
                   
                },
                Message="get successful",
                Status=true

            };
        }

        public UserResponsModel GetUserByEmail(string email)
        {
            var user = _userRepository.GetByExpression(y=>y.Email==email);
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
                Data = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    PhoneNumber=user.PhoneNumber,
                    Gender=user.Gender,
                    Age=user.Age,
                    
                },
                Message = "get successful",
                Status = true

            };
        }




        public UsersResponseModel GetUsersByRole(string name)
        {
            var users = _userRepository.GetUsersByRole(name);
            if(users.Count==0)
            {
                return new UsersResponseModel
                {

                    
                    Message = "get Unsuccessful",
                    Status = false
                };
            }
          
            return new UsersResponseModel
            {
                
                Data = users.Select(r => new UserDto
                {

                    Email = r.User.Email,
                    Id = r.User.Id,
                    UserRoles = r.User.UserRoles.Select(t => new UserRoleDto
                    {
                        Id = t.User.Id,
                        Name = t.Role.Name,
                    }).ToList(),

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
                   
                    Email = r.Email,
                    Age=r.Age,
                    Gender=r.Gender,
                    Id=r.Id,
                    UserRoles = r.UserRoles.Select(t => new UserRoleDto
                    {
                     Id=t.Id,   
                     Name=t.Role.Name,
                    }).ToList(),
                    
                  
                   
                }).ToList(),
                Message = "get successful",
                Status = true
            };

        }



        public LoginResponseModel LogIn(LoginUserRequest userrequest)
        {

            var user = _userRepository.GetUser(userrequest.EmailAddress);
           


            if (user == null)
            {
                return new LoginResponseModel
                {
                    Message = "invalid credentials",
                    Status = false,
             
                };
            }
            else
            {
                var verify = BCrypt.Net.BCrypt.Verify(userrequest.PassWord, user.PassWord);
                if (user != null && verify ==false)
                {
                    return new LoginResponseModel
                    {
                        Message = "invalid credentials",
                        Status = false,

                    };
                }
               
                return new LoginResponseModel
                {
                    Message = "Login Suvccessful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserRoles = user.UserRoles.Select(x => new UserRoleDto
                        {
                              Id = x.Id,
                              Name = x.Role.Name
                        }).ToList()
                    },
                };
               
            }
        }




        public BaseResponse CollectPreviousTime(string email,DateTime time)
        {

            var user = _userRepository.GetUser(email);
            user.PreviousLoggedInTime = user.LoggedInTime;
            user.LoggedOutTime= time;
            _userRepository.Update(user);
            return new BaseResponse
            {
                Message = "Successful",
                Status=true,
            };
        }


        //public BaseResponse ViewQuestions(int userId)
        //{
        //    var user = _userRepository.GetUser(userId);
        //    if (user == null)
        //    {
        //        return new BaseResponse
        //        {
        //            Message = "user does not exist",
        //            Status = false,
        //        };
        //    }
        //    var userViews = _userRepository.GetUserViews(user.Id);
        //    var questions = _questionRepository.GetAll();
        //    foreach (var question in questions)
        //    {
        //        var view = userViews.Views.Where(r => r.Question != question);

        //        if (!view.Any())
        //        {
        //            var vie = new View()
        //            {
        //                Question = question,
        //                QuestionId = question.Id,
        //                UserId = userId,
        //            };
        //            user.Views.Add(vie);
        //            _userRepository.Update(user);
        //        }
        //        else
        //        {
        //            foreach (var vie in view)
        //            {
        //                var vies = new View()
        //                {
        //                    Question = question,
        //                    QuestionId = question.Id,
        //                    UserId = userId,
        //                };
        //                user.Views.Add(vies);
        //            }
        //            _userRepository.Update(user);
        //        }
        //    }
        //    return new BaseResponse
        //    {
        //        Message = "Viewed succesful",
        //        Status = true
        //    };
        //}



        //public BaseResponse ViewAnswers(int userId, int questionId)
        //{
        //    var user = _userRepository.GetUser(userId);
        //    if (user == null)
        //    {
        //        return new BaseResponse
        //        {
        //            Message = "user does not exist",
        //            Status = false,
        //        };
        //    }
        //    var question = _questionRepository.GetQuestionById(questionId);
        //    if (question != null)
        //    {
        //        return new BaseResponse
        //        {
        //            Message = "Question not found",
        //            Status = false,
        //        };
        //    }
        //    else
        //    {
        //        if (question.Answers.Count == 0)
        //        {
        //            return new BaseResponse
        //            {
        //                Message = "Question not found",
        //                Status = false,
        //            };
        //        }
        //        else
        //        {
        //            foreach (var ans in question.Answers)
        //            {
        //                var ansView = new View()
        //                {
        //                    Answer = ans,
        //                    AnswerId = ans.Id,
        //                    Question = question,
        //                    QuestionId = question.Id,
        //                    UserId = userId,
        //                };
        //                user.Views.Add(ansView);
        //            }
        //            _userRepository.Update(user);
        //        }
        //        return new BaseResponse
        //        {
        //            Message = "Viewed succesful",
        //            Status = true
        //        };
        //    }

        //}





        public BaseResponse UpdateUserRole(UpdateUserRoleRequest request, int id)
        {
            var user = _userRepository.GetUser(request.Email);
            var role = _roleRepository.GetRole(request.RoleName);
            if(user == null)
            {
                return new BaseResponse
                {
                    Message = "User not found",
                    Status = false,
                };
            }
            var userrole = new UserRole
            {
                CreatedBy = id,
                IsDeleted = false,
                Role = role,
                RoleId = role.Id,
                User=user,
                UserId = user.Id,
                LastModifiedOn = DateTime.Now,
            };
            user.UserRoles.Add(userrole);
           
            _userRepository.Update(user);
            return new BaseResponse
            {
                Message = "Updated succesfully",
                Status = true,
            };

        }
    }
}
