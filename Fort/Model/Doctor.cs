using Fort.Contract;
using Fort.Identity;
namespace Fort.Model
{
    public class Doctor:Auditable_entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public string Year { get; set; }
        public int UserId { get; set; }
        public string Specialization { get; set; }
        public Approval ValidateDoctor { get; set; }
        public User ApplicationUser { get; set; }
    }
}
