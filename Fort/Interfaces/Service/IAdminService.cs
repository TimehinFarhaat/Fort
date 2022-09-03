using Fort.DTOs;

namespace Fort.Interfaces.Service

{
    public interface IAdminService
    {
        public BaseResponse AddAdmin(CreateAdminRequest Adminrequest);
        public AdminResponsModel GetAdminById(int id);
        public AdminResponsModel GetAdminByEmail(string email);
        public BaseResponse UpdateAdmin(UpdateAdminRequest request, int id);
        public BaseResponse DeleteAdmin(int id);
        public AdminsResponseModel GetAdmins();


    }
}
