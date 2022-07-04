using Fort.DTOs;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
    public class AnswerService : IAnswerService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        public AnswerService(IRoleRepository roleRepository, IAdminRepository adminRepository, IUserRepository userRepository, IQuestionRepository questionRepository,IAnswerRepository answerRepository)
        {
            _roleRepository = roleRepository;
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public BaseResponse CreateAnswer(CreateAnswerRequest answers, int questionID)
        {
            var question = _questionRepository.GetByExpression(c => c.Id == questionID);
            if (question == null)
            {
                return new BaseResponse
                {
                    Message = "question not available",
                    Status = false
                };
            }
            else
            {
                var answer = new Answer
                {
                    Description = answers.Description,
                    QuestionId = questionID,
                    Question = question,
                 
                };
                _answerRepository.Add(answer);
                return new BaseResponse
                {
                    Message = "successful",
                    Status = true
                };
            }
        }
        


        public BaseResponse CreateAnswer(CreateAnswerRequest answers, IList<int> id)
        {
            var questions = _questionRepository.GetByListOfId(id);
            if (questions== null)
            {
                return new AnswersResponse
                {
                    Message = "questions not available",
                    Status = false
                };
            }
            foreach (var quest in questions)
            {
                var answe = new Answer
                {
                    Description = answers.Description,
                    QuestionId = quest.Id,
                    Question = quest,
                };
                _answerRepository.Add(answe);
            };
            return new BaseResponse
            {
                Message = "successful",
                Status = true
            };
        }


        public BaseResponse DeleteAnswer(int answerId)
        {
            var answer = _answerRepository.GetByExpression(t => t.Id == answerId && t.IsDeleted == false);
            if (answer == null)
            {
                return new BaseResponse
                {
                    Message = " answer not available",
                    Status = false
                };
            }
            answer.IsDeleted = true;
            _answerRepository.Update(answer);
            return new BaseResponse
            {


                Message = "Dleted sucessful",
                Status = true,
            };

        }

        public AnswersResponse GetAnswersToQuestions(int QuestionId)
        {
            var answer = _answerRepository.GetByExpressions(t => t.QuestionId == QuestionId);
            if (answer == null)
            {
                return new AnswersResponse
                {
                    Message = "no answers",
                    Status = false
                };
            }
            return new AnswersResponse
            {
                Data = answer.Select(c => new AnswerDto
                {
                    Description = c.Description,
                }).ToList(),

                Message = "no answers",
                Status = false
            };

        }



    }
}