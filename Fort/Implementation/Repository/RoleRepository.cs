using Fort.Context;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fort.Implementation.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public Role GetRole(int id)
        {
            var rol = _context.Roles.Include(x => x.ApplicationUserRoles).
                               ThenInclude(x => x.User).SingleOrDefault(o => o.Id == id && o.IsDeleted == false);
            return rol;
        }



        public IList<Role> GetRoles()
        {
            var roles = _context.Roles.Include(x => x.ApplicationUserRoles ).
                                 ThenInclude(x => x.User).Where(y=>y.IsDeleted==false).ToList();
            return roles;
        }



        public IList<Role> GetSelectedRoles(IList<int> ids)
        {
            var roles = _context.Roles.Where(x => ids.Contains(x.Id) ).ToList();
            return roles;
        }
    }
}
