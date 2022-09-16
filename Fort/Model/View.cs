using Fort.Contract;
using Fort.Identity;

namespace Fort.Model
{
    public class View:Auditable_entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
