using Fort.Contract;
using Fort.Identity;
using Fort.Model;
namespace Fort.Model
{
    public class Admin:Auditable_entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public int UserId { get; set; }
        public User ApplicationUser { get; set; }
    }
}
