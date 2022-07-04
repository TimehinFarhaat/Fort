namespace Fort.DTOs
{
    public class AnswerDto
    {
        public string Description { get; set; }
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
