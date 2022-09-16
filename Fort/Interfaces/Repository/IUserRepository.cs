using Fort.Identity;
using System.Linq.Expressions;

namespace Fort.Interfaces.Repository
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public User GetUser(int id);
        public User GetUser(string email);
        public IList<User> GetUsers();


        public IList<UserRole> GetUsersByRole(string name);
        //public User GetByExpression(Expression<Func<User, bool>> expression);
    }
}
