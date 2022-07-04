using Fort.DTOs;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
     
    public class QuestionService : IQuestionService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IUserRepository userRepository, IQuestionRepository questionRepository)
        {
            _userRepository = userRepository ;
            _questionRepository = questionRepository ;
        }

        public BaseResponse CreateQuestion(CreateQuestionRequest questions,int userId)
        {
            var user=_userRepository.GetUser(userId);
            if(user != null)
            {
                var question = new Question
                {
                    Description = questions.Description,
                    UserId =user.Id,
                    User= user, 
                };
                _questionRepository.Add(question);
                return new BaseResponse
                {
                    Message = "successful",
                    Status = true
                };
            }
         
            return new BaseResponse
            {
                Message = "Unsuccessful",
                Status = false,
            };



        }

        public BaseResponse DeleteQuestion(int questionId)
        {
            var question = _questionRepository.GetByExpression(n => n.Id == questionId);
            if (question == null)
            {
                return new BaseResponse
                {
                    Message = "Not found",
                    Status = false

                };
            }
            question.IsDeleted = true;
            _questionRepository.Update(question);
            return new BaseResponse
            {
                Message = "deleted successfully",
                Status = true

            };

        }


        public QuestionsResponse GetQuestions()
        {
            var questions = _questionRepository.GetAll();
            if (questions != null)
            {
                return new QuestionsResponse
                {
                    Data = questions.Select(x => new QuestionDto
                    {
                        Description = x.Description,

                    }).ToList(),
                    Message = "Successful",
                    Status = true
                };
            }
            return new QuestionsResponse
            {
                Message = "unSuccessful",
                Status = false
            };
        }

        public QuestionsResponse GetQuestionsByUser(int userId)
        {
            var questions=_questionRepository.GetByExpressions(u=>u.UserId== userId);

            if(questions != null)
            {
                return new QuestionsResponse
                {
                    Data = questions.Select(x => new QuestionDto
                    {
                        Description = x.Description,

                    }).ToList(),
                    Message = "Successful",
                    Status = true
                };
            }
            return new QuestionsResponse
            {
                Message = "unSuccessful",
                Status = false
            };
        }
    }
}
