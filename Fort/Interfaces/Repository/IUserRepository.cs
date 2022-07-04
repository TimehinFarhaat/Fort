using Fort.Identity;

namespace Fort.Interfaces.Repository
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public User GetUser(int id);
        public IList<User> GetUsers();
        public IList<User> GetUsersByRole(string name);
    }
}
