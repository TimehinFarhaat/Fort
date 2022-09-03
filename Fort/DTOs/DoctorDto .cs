namespace Fort.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string LastName { get; set; }
        public ICollection<string> userRoles { get; set; } = new HashSet<string>();
        public string Email { get; set; }
        public string Gender { get; set; }
      
        public string Specialization { get; set; }
        
    }




    public class CreateDoctorRequest
    {
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public int Age { get; set; }
        

        public string PassWord { get; set; }
    }


    public class UpdateDoctorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string PassWord { get; set; }
    }

    public class DoctorResponsModel : BaseResponse
    {
        public DoctorDto Data { get; set; }
    }

    public class DoctorsResponseModel : BaseResponse
    {
        public IList<DoctorDto> Data { get; set; }
    }
}

