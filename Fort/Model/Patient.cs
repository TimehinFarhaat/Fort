using Fort.Identity;
using Fort.Contract;
using Fort.Model;

namespace Fort.Model
{
    public class Patient:Person
    {
      
       
        public int userId { get; set; }
        public User User { get; set; }
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public ICollection<PatientCheckup> PatientCheckup { get; set; } = new HashSet<PatientCheckup>();
        
    }
}
