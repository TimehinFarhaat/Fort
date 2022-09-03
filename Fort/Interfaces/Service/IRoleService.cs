using Fort.DTOs;
using Fort.Identity;

namespace Fort.Interfaces.Service
{
    public interface IRoleService
    {
        BaseResponse AddRole(CreateRoleRequest role);
        BaseResponse UpdateRole(UpdateRoleRequest role,int id);
        RoleResponsModel GetRole(int id);
        public BaseResponse DeleteRole(int roleId);
       
        RoleResponseModel GetRoles();
        RoleResponseModel GetSelectedRoles(IList<int> Ids);
    }
}
