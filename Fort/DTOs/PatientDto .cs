using Fort.Model;

namespace Fort.DTOs
{
    public class PatientDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public string Gender { get; set; }
        public ICollection<string> userRoles { get; set; } = new HashSet<string>();
        public int Age { get; set; }
        public string Email { get; set; }
        public ICollection<PatientCheckup> Symptoms { get; set; } = new HashSet<PatientCheckup>();

    }




        public class CreatePatientRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string EmailAddress { get; set; }
       

        public string PassWord { get; set; }
        }


        public class UpdatePatientRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; } 
            public string PhoneNumber { get; set; }
            
            public int Age { get; set; }
            public string EmailAddress { get; set; }        
            
        }

        public class PatientResponsModel : BaseResponse
        {
            public PatientDto Data { get; set; }
        }

        public class PatientResponseModel : BaseResponse
        {
            public IList<PatientDto> Data { get; set; }
        }
    
}
