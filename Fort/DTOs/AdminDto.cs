using Fort.Identity;

namespace Fort.DTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public string Gender { get; set; }
        public ICollection<string> userRoles { get; set; } = new HashSet<string>();
        public int Age { get; set; }
        public string Email { get; set; }
       
        

    }




    public class CreateAdminRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phonenumber { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
       

        public string PassWord { get; set; }
    }


    public class UpdateAdminRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
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

