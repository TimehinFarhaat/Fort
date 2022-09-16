using Fort.Contract;
using Fort.Model;
namespace Fort.Identity
{
    public class User:Auditable_entity
    {

        public string Email { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Admin Admin { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<View> Views { get; set; } = new HashSet<View>();
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

    }
}
