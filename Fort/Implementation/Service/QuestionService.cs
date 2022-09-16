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
        private readonly IPatientRepository _patientRepository;
        private readonly IAnswerRepository _answerRepository;

        public QuestionService(IUserRepository userRepository, IQuestionRepository questionRepository, IPatientRepository patientRepository,IAnswerRepository answerRepository)
        {
            _userRepository = userRepository ;
            _questionRepository = questionRepository ;
            _answerRepository = answerRepository ;
             _patientRepository=patientRepository ;
        }

        public BaseResponse CreateQuestion(CreateQuestionRequest questions,int userId)
        {
            var user=_userRepository.GetUser(userId);
                                                                                                             
            if(user != null ) 
            {
                var patient=_patientRepository.GetpatientById(user.Id);
                var question = new Question
                {
                    Description = questions.Description,
                    CreatedBy=userId,
                    PatientId=patient.Id,
                    Patient=patient,
                    LastModifiedBy=userId,
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
            question.Answers.Clear();
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
            var questions = _questionRepository.GetQuestions();
            

            if (questions.Count != 0)
            {
                return new QuestionsResponse
                {
                    Data = questions.Select(x => new QuestionDto
                    {
                        Description = x.Description,
                        QuestionId = x.Id,
                        AnswerContent = x.Answers.Select(y => new AnswerDto
                        {
                           Description = y.Description,
                            DoctorName = y.Doctor.FirstName + y.Doctor.LastName,
                           PositiveRating = y.PositiveRating,
                           NegativeRating = y.NegativeRating,
                           AnswerId = x.Id,
                           
                        }).ToList()

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


        public QuestionResponse GetQuestionById(int id)
        {
            var questions = _questionRepository.GetQuestionById(id);
            var ans = _answerRepository.GetAnswersToQuestion(questions.Id);

            if (questions.Id == id)
            {
                return new QuestionResponse
                {  
                    Data = new QuestionDto
                    {
                        Description = questions.Description,
                        QuestionId=questions.Id,                        
                        AnswerContent =questions.Answers.Select(y => new AnswerDto
                        {
                            Description = y.Description,
                            AnswerId=y.Id,
                            DoctorName = y.Doctor.FirstName + y.Doctor.LastName,
                            QuestionDescription = questions.Description,
                            NegativeRating = y.NegativeRating,
                            PositiveRating=y.PositiveRating,
                        }).ToList()

                    },
                    Message = "Successful",
                    Status = true,
                };
            }
            return new QuestionResponse
            {
                Message = "unSuccessful",
                Status = false
            };

        }



        public QuestionsResponse GetQuestionsByUser(int userId)
        {
            var user = _userRepository.GetUser(userId);
            
            if(user == null)
            {
                return new QuestionsResponse
                {
                    Message = "unSuccessful",
                    Status = false
                };
            }
            var p = _patientRepository.GetpatientById(user.Id);

            if (p == null)
            {
                return new QuestionsResponse
                {
                    Message = "Patient does not exist",
                    Status = false
                };


            }
            var questions = _questionRepository.GetUserQuestions(user.Email);
            if (questions.Count > 0)
            {
                return new QuestionsResponse
                {
                    Data = questions.Select(x => new QuestionDto
                    {
                        Description = x.Description,
                        AnswerContent = x.Answers.Select(y => new AnswerDto
                        {
                            Description = y.Description,
                            DoctorName = y.Doctor.FirstName + y.Doctor.LastName,
                            QuestionDescription = y.Description,
                            NegativeRating = y.NegativeRating,
                            AnswerId=y.Id,
                            PositiveRating=y.PositiveRating,
                        }).ToList()

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
