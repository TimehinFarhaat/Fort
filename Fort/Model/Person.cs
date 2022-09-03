using Fort.Contract;

namespace Fort.Model
{
    public abstract class Person:Auditable_entity
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        
        public DateTime DateOfBirth { get; set; }
       
    }
}
