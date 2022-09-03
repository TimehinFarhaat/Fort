using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IAnswerService
    {
        public BaseResponse CreateAnswer(CreateAnswerRequest answer,int id,int DoctorId);
        public AnswersResponse GetDoctorAnswers(int DoctorId);
        public AnswersResponse GetAnswersToQuestion(int  QuestionId);
        public BaseResponse DeleteAnswer(int answerId);


    }
}
