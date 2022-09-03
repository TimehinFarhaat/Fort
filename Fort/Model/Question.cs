using Fort.Contract;
using Fort.Identity;

namespace Fort.Model
{
    public class Question : Auditable_entity
    {

        public bool RecievedResponse { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}