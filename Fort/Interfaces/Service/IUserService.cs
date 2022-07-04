using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IUserService
    {

        public LoginResponseModel LogIn(LoginUserRequest Adminrequest);
        public UserResponsModel GetUserById(int id);
        public BaseResponse DeleteUser(int userId);
        public UsersResponseModel GetUsers();
        public UsersResponseModel GetUsersByRole(string name);
    }
}
