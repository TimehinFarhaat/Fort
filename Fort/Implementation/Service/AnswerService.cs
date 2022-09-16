using Fort.DTOs;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
    public class AnswerService : IAnswerService
    {
        
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IResponseService _responseService;
        private readonly IPatientRepository _patientRepository;
        public AnswerService( IAdminRepository adminRepository, IUserRepository userRepository, IQuestionRepository questionRepository,IAnswerRepository answerRepository,IResponseService responseService,IDoctorRepository doctorRepository,IPatientRepository patientRepository)
        {
            
            _adminRepository = adminRepository;
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _responseService = responseService;
            _patientRepository = patientRepository;
            
        }

        public BaseResponse CreateAnswer(CreateAnswerRequest answers, int questionID, int DoctorId)
        {
            var question = _questionRepository.GetQuestionById( questionID);
            var user = _userRepository.GetByExpression(c => c.Id == DoctorId);


            if (question == null || user == null)
            {

                return new BaseResponse
                {
                    Message = "question not available",
                    Status = false
                };
            }
            else
            {
                var doctor = _doctorRepository.GetDoctor(user.Id);
                if (doctor == null)
                {
                    return new BaseResponse
                    {
                        Message = "doctor not available",
                        Status = false
                    };
                }
                var answer = new Answer
                {
                    Description = answers.Description,
                    QuestionId = question.Id,
                    Question = question,
                    DoctorId = doctor.Id,
                    CreatedBy=doctor.Id,
                    Doctor = doctor,
                    CreatedOn = DateTime.Now,


                };
                var patient=_patientRepository.GetpatientById(user.Id);
              var questioneer= _userRepository.GetByExpression(v=>v.Id== question.Patient.Id);
                _answerRepository.Add(answer);
                var response = _responseService.SendResponse(questioneer.PhoneNumber,answer.Description);
                if (response.Status == TaskStatus.Faulted)
                {
                    return new BaseResponse
                    {
                        Message = "Inavlid Phone Number",
                        Status = response.IsFaulted,
                    };
                }

                return new BaseResponse
                {
                    Message = "successful",
                    Status = response.Result.Status,
                };
            }
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

        public AnswersResponse GetAnswersToQuestion(int QuestionId)
        {
            var answer = _answerRepository.GetAnswersToQuestion(QuestionId);
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
                    QuestionDescription =c.Question.Description,
                    AnswerId=c.Id,
                    NegativeRating = c.NegativeRating,
                    PositiveRating=c.NegativeRating,
                    DoctorName=c.Doctor.FirstName+" "+c.Doctor.LastName
                }).ToList(),

                Message = "answers",
                Status = true
            };

        }




        public BaseResponse AddRating(int Id)
        {
            var answer = _answerRepository.GetByExpression(s => s.Id == Id);
            if (answer== null)
            { 
                return new BaseResponse
                {
                    Message = "Answer does not exist",
                    Status = false
                };
            }
            else
            {
                answer.PositiveRating += 1;
                _answerRepository.Update(answer);
                return new BaseResponse
                {
                    Message = "Successful",
                    Status = true,
                };
            }
       
        }


        public BaseResponse RemoveRating(int Id)
        {
            var answer = _answerRepository.GetByExpression(s => s.Id == Id);
            if (answer == null)
            {
                return new BaseResponse
                {
                    Message = "Answer does not exist",
                    Status = false
                };
            }
            else
            {
                answer.PositiveRating -= 1; 
                answer.NegativeRating  += 1;
                _answerRepository.Update(answer);
                return new BaseResponse
                {
                    Message = "Successful",
                    Status = true,
                };
            }

        }



        public AnswersResponse GetDoctorAnswers(int DoctorId)
        {
            var user=_userRepository.GetUser(DoctorId);
            
            if(user == null)
            {
                return new AnswersResponse
                {
                    Message = "Doctor does not exist",
                    Status = false
                };
            }
            var doctor = _doctorRepository.GetDoctor(user.Id);
            var answer = _answerRepository.GetAnswersByDoctorId(doctor.Id);
            if (answer == null)
            {
                return new AnswersResponse
                {
                    Message = "no answers",
                    Status = true
                };
            };
            return new AnswersResponse
            {
                Data = answer.Select(c => new AnswerDto
                {
                    Description = c.Description,
                    AnswerId=c.Id,
                    NegativeRating=c.NegativeRating,
                    PositiveRating=c.PositiveRating,
                    QuestionDescription=c.Question.Description,
                    DoctorName = c.Doctor.FirstName + " " + c.Doctor.LastName
                }).ToList(),

                Message = "answers",
                Status = true,
            };

        }



    }
}