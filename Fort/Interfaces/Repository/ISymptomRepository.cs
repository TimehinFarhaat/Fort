using Fort.Model;

namespace Fort.Interfaces.Repository
{
    public interface ISymptomRepository:IBaseRepository<Symptom>
    {
        public Symptom GetSymptom(string name);
    }
}
