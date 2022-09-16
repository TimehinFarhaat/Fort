using Fort.Context;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Fort.Implementation.Repository
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {

        public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public User GetUser(int id)
        {
             var user=_context.Users.Include(e=>e.UserRoles).ThenInclude(s=>s.Role).Include(f=>f.Views).SingleOrDefault(u=>u.Id== id && u.IsDeleted== false);
            return user;
        }
      
        public User GetUser(string email )
        {
            var user = _context.Users.Include(u=>u.UserRoles).ThenInclude(s=>s.Role).Include(f=>f.Views).SingleOrDefault(u => u.Email == email && u.IsDeleted == false);
            return user;
        }

        public IList<User> GetUsers()
        {
            var users = _context.Users.Include(t=>t.UserRoles).ThenInclude(y=>y.Role).Where(u => u.IsDeleted == false).ToList();
            return users;
        }

      
        public IList<UserRole> GetUsersByRole(string name)
        {

            var rol = _context.UserRoles.Include(t=>t.User).Include(y => y.Role)
                .Where(u => u.Role.Name == name);
        
            
            return rol.ToList();
        }

        //public User GetUserViews(int userId)
        //{
        //    var userViews = _context.Users.Include(y => y.Views).SingleOrDefault(t => t.Id == userId);
        //    return userViews;
        //}
    }
}
