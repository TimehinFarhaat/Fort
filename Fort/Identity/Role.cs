using Fort.Contract;
namespace Fort.Identity
{
    public class Role:Auditable_entity
    {
       public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
