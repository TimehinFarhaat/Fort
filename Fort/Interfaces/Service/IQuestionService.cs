using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IQuestionService
    {
        public BaseResponse CreateQuestion(CreateQuestionRequest questionRequest,int id);
        public QuestionsResponse GetQuestionsByUser(int userId);
        public QuestionResponse GetQuestionById(int Id);
        public BaseResponse DeleteQuestion(int answerId);
        public QuestionsResponse GetQuestions();
        
    }
}
