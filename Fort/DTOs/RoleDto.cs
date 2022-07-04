using Fort.Identity;

namespace Fort.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User_role> Roles { get; set; }=new HashSet<User_role>();
    }




    public class CreateRoleRequest
    {
        public string Name { get; set; }
       
      
        public string Description { get; set; }
        
    }


    public class UpdateRoleRequest
    {
        public string Name { get; set; }


        public string Description { get; set; }
    }

    public class RoleResponsModel : BaseResponse
    {
        public RoleDto Data { get; set; }
    }

    public class RoleResponseModel : BaseResponse
    {
        public IList<RoleDto> Data { get; set; }
    }
}

