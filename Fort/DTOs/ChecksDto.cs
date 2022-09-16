namespace Fort.DTOs
{
    public class ChecksDto
    {
        public int CheckedQuestions { get; set; }
        public int QuestionCount { get; set; }
        public int UncheckedQuestions { get; set; }
        public int CheckedAnswers { get; set; }
        public int UnCheckedAnswers { get; set; }
        public int QuestionsAsked { get; set; }
         
    }
    public class ChecksDtoResponse : BaseResponse
    {

        public ChecksDto Data { get; set; }
    }
}
