using Fort.Interfaces.Repository;
using Fort.Model;

namespace Fort.Statistics
{
    public class ReturnAdminStatistics
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IDoctorRepository _doctorRepository;
  

        public ReturnAdminStatistics(IAdminRepository adminRepository, IPatientRepository patientRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, IDoctorRepository doctorRepository)
        {
            _adminRepository = adminRepository ;
            _patientRepository = patientRepository ;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository ;
            _doctorRepository = doctorRepository ;
            
        }

        private IList<Admin> GetAllAdmins()
        {
            var admins=_adminRepository.GetAdmins();
            return admins;
        }

        private IList<Patient> GetAllPatients()
        {
            return _patientRepository.GetPatients();
        }

        private IList<Doctor> GetAllDoctors()
        {
            return (_doctorRepository.GetDoctors());
        }

        private IList<Question> GetAllQuestions()
        {
            return _questionRepository.GetQuestions();
        }

        private IList<Answer> GetAllAnswers()
        {
            return _answerRepository.GetAll();
        }

        private IList<Question> GetAllAnsweredQuestions()
        {
            var question=_questionRepository.GetQuestions();
            var AnsweredQuestion=question.Where(s=>s.Answers.Count != 0).ToList();
            return AnsweredQuestion;
        }

        private IList<Question> GetAllUnAnsweredQuestions()
        {
            var question = _questionRepository.GetQuestions();
            var unAnsweredQuestion = question.Where(s => s.Answers.Count == 0).ToList();
            return unAnsweredQuestion;
        }


        private IList<Question> GetAllCheckedQuestions(int userId)
        {
            var admin=_adminRepository.GetAdmin(userId);
            var checkedQuestions=new List<Question>();
            var questions = _questionRepository.GetQuestions();
            foreach (var question in questions)
            {
                foreach (var view in admin.User.Views)
                {
                    if (view.QuestionId == question.Id)
                    {
                        checkedQuestions.Add(question);
                    }
                }
            }

            return checkedQuestions;
        }

        private IList<Question> GetAllUnCheckedQuestions(int userId)
        {
            var admin = _adminRepository.GetAdmin(userId);
            var views = admin.User.Views.ToList();
            var Questions=_questionRepository.GetQuestions();
            var unCheckedQuestions=new List<Question>();
            foreach(var question in Questions)
            {
                foreach(var viewQuestion in views)
                {
                    if (question.Id != viewQuestion.QuestionId)
                    {
                        unCheckedQuestions.Add(question);
                    }
                }
            }
            return unCheckedQuestions;

        }


        private IList<Answer> AllCheckedAnswers(int userId)
        {
            var admin = _adminRepository.GetAdmin(userId);
            var views = admin.User.Views.ToList();
            var checkedQuestions=GetAllCheckedQuestions(userId);
            var checkedAnswers=new List<Answer>();
            if(checkedQuestions.Count > 0)
            {
                return checkedAnswers;
            }
            foreach(var question in checkedQuestions)
            {
                foreach (var answer in question.Answers)
                {
                     foreach(var view in views)
                     {
                        if (answer.Id == view.AnswerId)
                        {
                            checkedAnswers.Add(answer);
                        }
                     }
                   
                }

            }
            return checkedAnswers;
        }


        private IList<Answer> AllUnCheckedAnswers(int userId)
        {
            var admin = _adminRepository.GetAdmin(userId);
            var views = admin.User.Views.ToList();
            var checkedQuestions = GetAllCheckedQuestions(userId);
            var UncheckedAnswers = new List<Answer>();
            if (checkedQuestions.Count > 0)
            {
                return UncheckedAnswers;
            }
            foreach (var question in checkedQuestions)
            {
                foreach (var answer in question.Answers)
                {
                    foreach (var view in views)
                    {
                        if (answer.Id != view.AnswerId)
                        {
                            UncheckedAnswers.Add(answer);
                        }
                    }

                }

            }
            return UncheckedAnswers;
        }
    }
}
