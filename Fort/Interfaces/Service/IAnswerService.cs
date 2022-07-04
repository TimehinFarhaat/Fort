using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IAnswerService
    {
        public BaseResponse CreateAnswer(CreateAnswerRequest answer,int id);
        public BaseResponse CreateAnswer(CreateAnswerRequest answer, IList<int> id);
        public AnswersResponse GetAnswersToQuestions(int  QuestionId);
        public BaseResponse DeleteAnswer(int answerId);


    }
}
