using Fort.Identity;

namespace Fort.DTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set;}
        public ICollection<User_role> UserRoles { get; set; }=new HashSet<User_role>(); 

    }




    public class CreateAdminRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public IList<int> UserRoles { get; set; }

        public string PassWord { get; set; }
    }


    public class UpdateAdminRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    public class AdminResponsModel : BaseResponse
    {
        public AdminDto Data { get; set; }
    }

    public class AdminsResponseModel : BaseResponse
    {
        public IList<AdminDto> Data { get; set; }
    }
}

