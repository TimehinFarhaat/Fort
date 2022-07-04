using Fort.Identity;

namespace Fort.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public ICollection<User_role> Roles { get; set; } = new HashSet<User_role>();
    }
     
    


    public class CreateUserRequest
    {
        
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
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

