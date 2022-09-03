using Fort.Identity;

namespace Fort.DTOs
{
    public class QuestionDto
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public  int QuestionId { get; set; }
        public IList<AnswerDto> AnswerContent { get; set; } = new List<AnswerDto>();  
    }

   

    public class CreateQuestionRequest
    {
        
        public string Description { get; set; }
    }

    public class UpdateQuestionRequest
    {
       
        public string Description { get; set; }
    }

    public  class QuestionResponse:BaseResponse
    {
        
        public QuestionDto Data { get; set; }
    }
    public class QuestionsResponse:BaseResponse
    {

        public IList<QuestionDto> Data { get; set; } = new List<QuestionDto>();
    }
}
