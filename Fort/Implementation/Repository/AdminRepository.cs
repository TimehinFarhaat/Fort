using Fort.Model;
using Fort.Implementation;
using Fort.Interfaces.Repository;
using Fort.Context;
using Fort.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Fort.Implementation.Repository
{
    public class AdminRepository:BaseRepository<Admin>,IAdminRepository
    {
      
        public AdminRepository(ApplicationContext applicationContext): base(applicationContext)
        {

        }


        public IList<Admin> GetAdmins()
        {
            var admins = _context.Admins.Include(x=>x.User).Where(i=>i.IsDeleted==false).ToList(); 
           return admins;
        }



        public Admin GetAdmin(int id)
        {
           
            var admin = _context.Admins.Include(x => x.User).ThenInclude(t=>t.UserRoles).ThenInclude(r=>r.Role).SingleOrDefault(x => x.User.Id == id && x.IsDeleted==false);    
            return admin;
        }

        public Admin GetAdmin(string email)
        {

            var admin = _context.Admins.Include(x => x.User).ThenInclude(y=>y.UserRoles).ThenInclude(y=>y.Role).FirstOrDefault(x => x.User.Email == email && x.IsDeleted == false);
            return admin;
        }

    }

}
