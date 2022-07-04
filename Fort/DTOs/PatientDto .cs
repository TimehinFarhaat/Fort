using Fort.Model;

namespace Fort.DTOs
{
    public class PatientDto
    {
            public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
            public string PassWord { get; set; }
        public ICollection<PatientCheckup> Symptoms { get; set; } = new HashSet<PatientCheckup>();

    }




        public class CreatePatientRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string EmailAddress { get; set; }
       

        public string PassWord { get; set; }
        }


        public class UpdatePatientRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string EmailAddress { get; set; }
            public ICollection<PatientCheckup> Symptoms { get; set; }=new HashSet<PatientCheckup>();
           
            public string PassWord { get; set; }
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
