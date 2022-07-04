using Fort.Contract;
using Fort.Model;
namespace Fort.Identity
{
    public class User:Auditable_entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public Admin ApplicationAdmin { get; set; }
        public Patient ApplicationPatient { get; set; }
        public Doctor ApplicationDoctor { get; set; }   
        public ICollection<Question> UserQuestions { get; set; }=new HashSet<Question>();   
        public ICollection<Answer> UserAnswers { get; set; }=new HashSet<Answer>();       
        public ICollection<User_role> ApplicationUserRoles { get; set; } = new HashSet<User_role>();
    }
}
