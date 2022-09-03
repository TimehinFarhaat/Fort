using Fort.Identity;
using System.Linq.Expressions;

namespace Fort.Interfaces.Repository
{
    public interface IRoleRepository:IBaseRepository<Role>
    {
        Role GetRole(int id);
        Role GetRole(string name);
        IList<Role> GetRoles();
        IList<Role> GetSelectedRoles(IList<int> Ids);
        public IList<Role> GetSelectedUserRole(IList<string> name);
        public IList<UserRole> GetUserRole(int UserId);


    }
}
