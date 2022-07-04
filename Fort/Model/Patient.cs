using Fort.Identity;
using Fort.Contract;
using Fort.Model;

namespace Fort.Model
{
    public class Patient:Auditable_entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Year { get; set; }
        public string EmailAddress { get; set; }
        public int ApplicationuserId { get; set; }
        public User ApplicationUser { get; set; }
        public ICollection<PatientCheckup> PatientCheckup { get; set; } = new HashSet<PatientCheckup>();
        
    }
}
