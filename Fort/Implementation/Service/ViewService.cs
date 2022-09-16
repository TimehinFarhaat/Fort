using Fort.DTOs;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
    public class ViewService : IViewService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IViewRepository _viewRepository;

        public ViewService(IUserRepository userRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _userRepository = userRepository ;
            _questionRepository = questionRepository ;
            _answerRepository = answerRepository ;
        }

        public BaseResponse ViewAnswers(int userId, int questionId)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return new BaseResponse
                {
                    Message = "User Not Found",
                    Status = false
                };
            }
            var userViews = _viewRepository.GetByUserId(userId);
            var view=userViews.Where(x => x.QuestionId == questionId).SingleOrDefault();
            foreach (var answer in view.Question.Answers)
            {
                if (!view.Question.Answers.Contains(answer))
                {
                    var viewIndex=userViews.IndexOf(view);
                    var view1=userViews[viewIndex];
                    view1.Answer = answer;
                   _viewRepository.Update(view1);    
                }
                _userRepository.Update(user);
            }
            return new BaseResponse
            {
                Message = "Successful",
                Status = true
            };
        }



        public BaseResponse ViewQuestions(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if(user == null)
            {
                return new BaseResponse
                {
                    Message = "User Not Found",
                    Status=false
                };
            }
            var userViews=_viewRepository.GetByUserId(userId);
            var questions = _questionRepository.GetQuestions();
            if(questions != null)
            {
                if (userViews.Count == 0)
                {
                    foreach (var question in questions)
                    {
                        var view = new View()
                        {
                            QuestionId = question.Id,
                            UserId = userId,
                        };
                        userViews.Add(view); 
                        _viewRepository.Add(view);
                    }
                    _userRepository.Update(user);
                }
                else
                {
                    foreach(var question in questions)
                    {
                        foreach(var viewObject in userViews)
                        {
                            if(viewObject.QuestionId != question.Id)
                            {
                                var view = new View()
                                {
                                    QuestionId = question.Id,
                             
                                    UserId = userId,
                                   
                                };
                                userViews.Add(view);
                                _viewRepository.Add(view);
                            }
                        }
                    }
                    _userRepository.Update(user);
                }
            }

            return new BaseResponse
            {
                Message = "Successful",
                Status = true
            };

        }
    }
}
