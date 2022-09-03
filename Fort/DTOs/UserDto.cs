using Fort.Identity;

namespace Fort.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public string Gender { get; set; }
        public List<UserRoleDto> UserRoles { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }
      
     
    
    public class UserRoleDto
    {
        public int Id { get;set; }
        public string Name { get; set; }
    }

    public class CreateUserRequest
    {
        
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
    public class UpdateUserRoleRequest
    {

        public string RoleName { get; set; }
        public string Email { get; set; }
       
    }


    public class LoginUserRequest
    {
        public string EmailAddress { get; set; }
        
        public string PassWord { get; set; }
    }


    public class LoginResponseModel:BaseResponse
    {
       
        public string  Token { get; set; }

        public UserDto Data { get; set; }


    }


    public class UpdateUserRequest
    {
       
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    public class UserResponsModel : BaseResponse
    {
        public UserDto Data { get; set; }
    }

    public class UsersResponseModel : BaseResponse
    {
        public IList<UserDto> Data { get; set; }
    }
}

