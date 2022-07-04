using Fort.Identity;

namespace Fort.Interfaces.Repository
{
    public interface IRoleRepository:IBaseRepository<Role>
    {
        Role GetRole(int id);
        IList<Role> GetRoles();
        IList<Role> GetSelectedRoles(IList<int> Ids);
        
    }
}
