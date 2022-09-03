using Fort.DTOs;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;
using Fort.Model;

namespace Fort.Implementation.Service
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IAnswerRepository _answerRepository;
        public RatingService(IRatingRepository ratingRepository,IAnswerRepository answerRepository)
        {
            _ratingRepository = ratingRepository;
            _answerRepository = answerRepository;
        } 

        public BaseResponse AddRating(CreateRatingRequest ratingRequest,int AnswerId)
        {
            var answer = _answerRepository.GetByExpression(r => r.Id == AnswerId);
            if(answer  == null)
            {
                return new BaseResponse()
                {
                    Message = "Answer does not exist",
                    Status = false,
                };
            }
            var rating = new Rating
            {
                Answer = answer,
                AnswerId = answer.Id,
                Value = ratingRequest.Value
            };
            _ratingRepository.Add(rating);
            return new BaseResponse
            {
                Message = "Rated Successful",
                Status = true
            };
        }

      

        public RatingsResponse GetRatingsByAnswerId(int id)
        {
            var ratings = _ratingRepository.GetRating(id);
            if(ratings.Count == 0)
            {
                return new RatingsResponse
                {
                    Message = "Invalid answer",
                    Status = false
                };
            }
            return new RatingsResponse
            {
                Data = ratings.Select(rating => new RatingDto
                {
                    Value = rating.Value,
                    AnswerId = rating.AnswerId,
                    Id = rating.Id

                }).ToList(),
                Message =" Successful",
                Status=true,
            };
        }




        public RatingResponse GetAnswerRating(int id)
        {
            var answerRating = _answerRepository.GetByExpression(r => r.Id == id);
            if(answerRating == null)
            {
                return new RatingResponse
                {
                    Message = "Invalid answer",
                    Status = false
                };

            }
            return new RatingResponse
            {
                Data = new RatingDto
                {
                    AnswerId = answerRating.Id,
                    Value = answerRating.Rating
                },
                Message = "Get Successful",
                Status = true
            };

        }


        public BaseResponse AddAnswerRating(int id)
        {
            var answer = _answerRepository.GetByExpression(r => r.Id == id);
            var ratings = _ratingRepository.GetRating(answer.Id);
            if (ratings.Count == 0)
            {
                return new RatingsResponse
                {
                    Message = "Invalid answer",
                    Status = false
                };
            }
            else
            {
                var num = 0;
                foreach(var rat in ratings)
                {
                    num += rat.Value;
                };
                var rate=num/ratings.Count;
                var rates = rate / 20;
                answer.Rating=rates;
                _answerRepository.Update(answer);
                return new BaseResponse
                {
                    Message = "Added successfully",
                    Status = true
                };
                
            }
            
        }
    

      
    }
}
