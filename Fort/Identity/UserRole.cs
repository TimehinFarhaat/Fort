using Fort.Contract;
using Fort.Model;
namespace Fort.Identity
{
    public class UserRole:Auditable_entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        
        public Role Role { get; set; }
    }
}
