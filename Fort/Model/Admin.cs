using Fort.Contract;
using Fort.Identity;
using Fort.Model;
namespace Fort.Model
{
    public class Admin:Person
    {
  
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
