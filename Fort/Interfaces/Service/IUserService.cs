using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IUserService
    {

        public LoginResponseModel LogIn(LoginUserRequest Adminrequest);
        public UserResponsModel GetUserById(int id);
        public UserResponsModel GetUserByEmail(string email);
        public BaseResponse DeleteUser(int userId);
        public UsersResponseModel GetUsers();
        public BaseResponse UpdateUserRole(UpdateUserRoleRequest request,int userId);
        public UsersResponseModel GetUsersByRole(string name);
    }
}
