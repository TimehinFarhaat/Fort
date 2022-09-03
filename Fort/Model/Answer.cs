using Fort.Contract;
using Fort.Identity;

namespace Fort.Model
{
    public class Answer:Auditable_entity
    {
       
      
        public int QuestionId { get; set; }
        public int Rating { get; set; }
        public Question Question { get; set; }
        public string Description { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
      
    }
}
