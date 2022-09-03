using Fort.DTOs;
using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IAdminRepository:IBaseRepository<Admin>
    {
        public IList<Admin> GetAdmins();
        public Admin GetAdmin(string email);
        public Admin GetAdmin(int id);
    }
   
}
