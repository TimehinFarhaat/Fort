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
        public Role GetRole(string name)
        {
            var rol = _context.Roles.Include(x => x.UserRoles).
                               ThenInclude(x => x.User).SingleOrDefault(o => o.Name == name && o.IsDeleted == false);
            return rol;
        }
        public Role GetRole(int id)
        {
            var rol = _context.Roles.Include(x => x.UserRoles).
                               ThenInclude(x => x.User).SingleOrDefault(o => o.Id== id && o.IsDeleted == false);
            return rol;
        }
        public IList<UserRole> GetUserRole(int UserId)
        {
            var user = _context.UserRoles.Where(u => u.UserId == UserId).ToList();
        
            return user;
        }



        public IList<Role> GetRoles()
        {
            var roles = _context.Roles.Where(y=>y.IsDeleted==false).ToList();
            return roles;
        }



        public IList<Role> GetSelectedRoles(IList<int> ids)
        {
            var roles = _context.Roles.Where(x => ids.Contains(x.Id) ).ToList();
            return roles;
        }

       


        public IList<Role> GetSelectedUserRole(IList<string> names)
        {
            var roles = _context.Roles.Where(r=>names.Contains(r.Name)).ToList();
            return roles;
        }

       
    }
}
