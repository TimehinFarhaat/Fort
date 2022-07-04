using Fort.Contract;

namespace Fort.Model
{
    public class Symptom:Auditable_entity
    {
        public string Name { get; set; }
        public ICollection<SymptomCheckup> SymptomCheckups { get; set; } = new HashSet<SymptomCheckup>();
    }
}
