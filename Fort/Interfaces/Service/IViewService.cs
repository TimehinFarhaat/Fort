using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IViewService
    {
        public BaseResponse ViewQuestions(int userId); 
        public BaseResponse ViewAnswers(int userId,int questionId); 
    }
}
