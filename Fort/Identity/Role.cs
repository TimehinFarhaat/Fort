using Fort.Contract;
namespace Fort.Identity
{
    public class Role:Auditable_entity
    {
       public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User_role> ApplicationUserRoles { get; set; } = new HashSet<User_role>();
    }
}
