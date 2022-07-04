using Fort.Contract;
using Fort.Identity;

namespace Fort.Model
{
    public class Answer:Auditable_entity
    {
       
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Description { get; set; }
    }
}
