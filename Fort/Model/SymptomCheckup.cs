using Fort.Contract;

namespace Fort.Model
{
    public class SymptomCheckup:Auditable_entity
    {
        public int SymptomId { get; set; }
        public Symptom Symptom { get; set; }
        public int CheckUpId { get; set; }
        public CheckUp Checkup { get; set; }
    }
}
