using Fort.Interfaces.Repository;
using Fort.Model;

namespace Fort.Statistics
{
    public class ReturnDoctorStatistics
    {
        
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IDoctorRepository _doctorRepository;


        public ReturnDoctorStatistics( IQuestionRepository questionRepository, IAnswerRepository answerRepository, IDoctorRepository doctorRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _doctorRepository = doctorRepository;

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

        private IList<Question> DoctorAnsweredQuestions(int userId)
        {
            var doctor = _doctorRepository.GetDoctor(userId);
            var questions = _questionRepository.GetQuestions();
            var doctorAnsweredQuestions = new List<Question>();
            foreach (var question in questions)
            {
                var ans = question.Answers.Where(e => e.DoctorId == doctor.Id);
                if (!ans.Any())
                {
                    return doctorAnsweredQuestions;
                }
                else
                {
                    doctorAnsweredQuestions.Add(question);

                }
            }
            return doctorAnsweredQuestions;
        }



        private IList<Question> DoctorUnAnsweredQuestions(int userId)
        {
            var doctor = _doctorRepository.GetDoctor(userId);
            var questions = _questionRepository.GetQuestions();
            var doctorUnAnsweredQuestions = new List<Question>();
            foreach (var question in questions)
            {
                var ans = question.Answers.Where(e => e.DoctorId != doctor.Id);
                if (!ans.Any())
                {
                    return doctorUnAnsweredQuestions;
                }
                else
                {
                    doctorUnAnsweredQuestions.Add(question);

                }
            }
            return doctorUnAnsweredQuestions;
        }




        private IList<Question> GetAllCheckedQuestions(int userId)
        {
            var doctor = _doctorRepository.GetDoctor(userId);
            var checkedQuestions = new List<Question>();
            var questions = _questionRepository.GetQuestions();
            foreach (var question in questions)
            {
                foreach (var view in doctor.User.Views)
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
            var doctor = _doctorRepository.GetDoctor(userId);
            var views = doctor.User.Views.ToList();
            var Questions = _questionRepository.GetQuestions();
            var unCheckedQuestions = new List<Question>();
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
            var doctor = _doctorRepository.GetDoctor(userId);
            var views = doctor.User.Views.ToList();
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
            var doctor = _doctorRepository.GetDoctor(userId);
            var views = doctor.User.Views.ToList();
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
