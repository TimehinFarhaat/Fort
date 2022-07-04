using Fort.Context;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fort.Implementation.Repository
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {

        public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public User GetUser(int id)
        {
             var user=_context.Users.Include(u=>u.ApplicationUserRoles).SingleOrDefault(u=>u.Id== id && u.IsDeleted== false);
            return user;
        }

        public IList<User> GetUsers()
        {
            var users = _context.Users.Include(u => u.ApplicationUserRoles).Where(u => u.IsDeleted == false).ToList();
            return users;
        }

        public IList<User> GetUsersByRole(string name)
        {
            var users = _context.Users.Include(u => u.ApplicationUserRoles.Where(u=>u.Role.Name==name && u.IsDeleted==false).ToList()).ToList();
           
            return users;
        }
    }
}
