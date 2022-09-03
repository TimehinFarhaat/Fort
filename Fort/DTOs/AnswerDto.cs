namespace Fort.DTOs
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }
      
        public string QuestionDescription { get; set; }
       public int  Rating { get; set; }
        public string Description { get; set; }
        public string DoctorName { get; set; }
    }
    public class CreateAnswerRequest
    {

        public string Description { get; set; }
    }

    public class UpdateAnswerRequest
    {

        public string Description { get; set; }
    }

    public class AnswerResponse:BaseResponse
    {

        public AnswerDto Data { get; set; }
    }
    public class AnswersResponse:BaseResponse
    {

        public IList<AnswerDto> Data { get; set; }
    }
}
