using Fort.Contract;
using Fort.Identity;

namespace Fort.Model
{
    public class Question : Auditable_entity
    {

        public bool RecievedResponse { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public ICollection<View> Views { get; set; } = new HashSet<View>();
        
       
        
    }
}