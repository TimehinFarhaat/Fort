using Fort.Model;

namespace Fort.DTOs
{
    public class CheckupDto
    {
        public int Id { get; set; }
        public IList<string> Symptom { get; set; } = new List<string>();
        public string Name { get; set; }   
        public string Description { get; set; }
        public ICollection<SymptomDto> SymptomDto { get; set; } = new HashSet<SymptomDto>();
      
    }




    public class CreateCheckupRequest
    {

        public IList<string> Symptoms { get; set; } = new List<string>();
        public string Name { get; set; }
        public string Description { get; set; }
      


    }


    public class UpdateCheckupRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

 
        
    }

    public class CheckupResponseModel: BaseResponse
    {
        public CheckupDto Data { get; set; }
    }

    public class CheckupResponseModels: BaseResponse
    {
        public IList<CheckupDto> Data { get; set; }
    }
}

