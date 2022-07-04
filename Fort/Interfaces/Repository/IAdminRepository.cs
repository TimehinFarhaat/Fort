using Fort.DTOs;
using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface IAdminRepository:IBaseRepository<Admin>
    {
        public IList<Admin> GetAdmins();
        public Admin GetAdmin(int id);
    }
   
}
