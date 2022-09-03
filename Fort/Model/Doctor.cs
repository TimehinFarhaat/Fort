using Fort.Contract;
using Fort.Identity;
namespace Fort.Model
{
    public class Doctor:Person
    {
     
        public string CertificatePath { get; set; }
        public int UserId { get; set; }
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public string Specialization { get; set; }
        public Approval ValidateDoctor { get; set; }
        public User User { get; set; }
    }
}
