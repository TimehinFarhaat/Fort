using Fort.Interfaces.Repository;
using Fort.Model;

namespace Fort.Statistics
{
    public class ReturnPatientStatistics
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IPatientRepository _patientRepository;


        public ReturnPatientStatistics(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IPatientRepository patientRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _patientRepository = patientRepository;

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
            var question = _questionRepository.GetQuestions();
            var AnsweredQuestion = question.Where(s => s.Answers.Count != 0).ToList();
            return AnsweredQuestion;
        }

        private IList<Question> GetAllUnAnsweredQuestions()
        {
            var question = _questionRepository.GetQuestions();
            var unAnsweredQuestion = question.Where(s => s.Answers.Count == 0).ToList();
            return unAnsweredQuestion;
        }

        

        private IList<Question> GetUserQuestions(int userId)
        {
            var patient = _patientRepository.GetpatientById(userId);
            return patient.Questions.ToList();
        }


        private IList<Answer> GetUncheckedUserQuestionsAnswer(int userId)
        {
            var patient = _patientRepository.GetpatientById(userId);
            var userQuestions = patient.Questions.ToList();
            var views = patient.User.Views.ToList();
            var  UnCheckeduserQuestionsAnswers= new List<Answer>();
            if(userQuestions == null || views== null || userQuestions==null) return UnCheckeduserQuestionsAnswers;
            foreach(var question in userQuestions)
            {
                foreach(var answer in question.Answers)
                {
                    foreach(var view in views)
                    {
                        if(view.AnswerId != answer.Id)
                        {
                            UnCheckeduserQuestionsAnswers.Add(answer);
                        }    
                    }
                }
            }
            return UnCheckeduserQuestionsAnswers;
        }



        private IList<Answer> GetCheckedUserQuestionsAnswer(int userId)
        {
            var patient = _patientRepository.GetpatientById(userId);
            var userQuestions = patient.Questions.ToList();
            var views = patient.User.Views.ToList();
            var CheckeduserQuestionsAnswers = new List<Answer>();
            if (userQuestions == null || views == null || userQuestions == null) return CheckeduserQuestionsAnswers;
            foreach (var question in userQuestions)
            {
                foreach (var answer in question.Answers)
                {
                    foreach (var view in views)
                    {
                        if (view.AnswerId == answer.Id)
                        {
                            CheckeduserQuestionsAnswers.Add(answer);
                        }
                    }
                }
            }
            return CheckeduserQuestionsAnswers;
        }





        private IList<Question> GetAllCheckedQuestions(int userId)
        {
            var patient = _patientRepository.GetpatientById(userId);
            var checkedQuestions = new List<Question>();
            var questions = _questionRepository.GetQuestions();
            if(checkedQuestions == null || questions == null) return checkedQuestions;
            foreach (var question in questions)
            {
                foreach (var view in patient.User.Views)
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
            var patient = _patientRepository.GetpatientById(userId);
            var views = patient.User.Views.ToList();
            var Questions = _questionRepository.GetQuestions();
            var unCheckedQuestions = new List<Question>();
            if (views == null || Questions == null) return unCheckedQuestions;
            foreach (var question in Questions)
            {
                foreach (var viewQuestion in views)
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
            var patient= _patientRepository.GetpatientById(userId);
            var views = patient.User.Views.ToList();
            var checkedQuestions = GetAllCheckedQuestions(userId);
            var checkedAnswers = new List<Answer>();
            if (checkedQuestions.Count > 0)
            {
                return checkedAnswers;
            }
            foreach (var question in checkedQuestions)
            {
                foreach (var answer in question.Answers)
                {
                    foreach (var view in views)
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
            var patient = _patientRepository.GetpatientById(userId);
            var views = patient.User.Views.ToList();
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
