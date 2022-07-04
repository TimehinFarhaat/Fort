
using Fort.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fort.Model
{
    public class CheckUp:Auditable_entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
       
        public ICollection<SymptomCheckup> SymptomCheckups { get; set; }   = new HashSet<SymptomCheckup>();   
        public ICollection<PatientCheckup> PatientCheckups { get; set; } = new HashSet<PatientCheckup>();
    }
}
