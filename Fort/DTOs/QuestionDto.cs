using Fort.Identity;

namespace Fort.DTOs
{
    public class QuestionDto
    {
        
        public string Description { get; set; }
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

        public IList<QuestionDto> Data { get; set; }
    }
}
