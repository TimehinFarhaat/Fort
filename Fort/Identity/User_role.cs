using Fort.Contract;
using Fort.Model;
namespace Fort.Identity
{
    public class User_role:Auditable_entity
    {
        public int ApplicationUserId { get; set; }
        public User User { get; set; }
        public int ApplicationRoleId { get; set; }
        
        public Role Role { get; set; }
    }
}
