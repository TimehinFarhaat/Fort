using Fort.Contract;
using Fort.Identity;

namespace Fort.Model
{
    public class Question:Auditable_entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public ICollection<Answer> answers { get; set; }=new HashSet<Answer>();
    }
}
