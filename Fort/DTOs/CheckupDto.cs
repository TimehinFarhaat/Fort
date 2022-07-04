using Fort.Model;

namespace Fort.DTOs
{
    public class CheckupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SymptomDto> Symptoms { get; set; } = new HashSet<SymptomDto>();
      
    }




    public class CreateCheckupRequest
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<int> SymptomsId { get; set; }=new HashSet<int>();


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

