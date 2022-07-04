using Fort.DTOs;

namespace Fort.Interfaces.Service

{
    public interface IAdminService
    {
        public BaseResponse AddAdmin(CreateAdminRequest Adminrequest,int adminId);
        public AdminResponsModel GetAdminById(int id);
        public AdminResponsModel GetAdminByEmail(string email);
        public BaseResponse UpdateAdmin(UpdateAdminRequest request, int id);
        public BaseResponse ApproveDoctor( string email);
        public BaseResponse DeleteAdmin(string email);
        public BaseResponse DisapproveDoctor(string email);
        public AdminsResponseModel GetAdmins();


    }
}
