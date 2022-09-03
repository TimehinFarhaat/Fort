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
             var user=_context.Users.SingleOrDefault(u=>u.Id== id && u.IsDeleted== false);
            return user;
        }
        public User GetUser(string email )
        {
            var user = _context.Users.Include(u=>u.UserRoles).ThenInclude(s=>s.Role).SingleOrDefault(u => u.Email == email && u.IsDeleted == false);
            return user;
        }

        public IList<User> GetUsers()
        {
            var users = _context.Users.Include(t=>t.UserRoles).ThenInclude(y=>y.Role).Where(u => u.IsDeleted == false).ToList();
            return users;
        }

       


        //public User GetByExpression(Expression<Func<User, bool>> expression)
        //{
        //    var user = _context.Users.Where(expression).Include(u => u.UserRoles).ThenInclude(p => p.Role).FirstOrDefault();
        //    return user;
        //}

       

        public IList<UserRole> GetUsersByRole(string name)
        {

            var rol = _context.UserRoles.Include(t=>t.User).Include(y => y.Role)
                .Where(u => u.Role.Name == name);
        
            
            return rol.ToList();
        }
    }
}
