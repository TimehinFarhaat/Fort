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
            var admins = _context.Admins.Include(x=>x.ApplicationUser).Where(i=>i.IsDeleted==false).ToList(); 
           return admins;
        }



        public Admin GetAdmin(int id)
        {
            var s = _context.Admins.FirstOrDefault(o => o.Id == id);
            if(s == null)
            {
                return null;
            }
            var admin = _context.Admins.Include(x => x.ApplicationUser).FirstOrDefault(x => x.Id == id&& x.IsDeleted==false);    
            return admin;
        }
    }
    
}
