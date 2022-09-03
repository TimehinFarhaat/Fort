using Fort.Contract;
using Fort.Identity;
using Fort.Model;

namespace Fort.Model
{
    public class PatientCheckup: Auditable_entity
    {
        public int PatientId { get; set; }  
        public  Patient Patient { get; set; }
        public int CheckUpId { get; set; }
        public CheckUp Checkup { get; set; }

        
    }
}
