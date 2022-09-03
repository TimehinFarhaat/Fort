using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IRatingService
    {
        public BaseResponse AddRating(CreateRatingRequest ratingRequest,int answerId);
        public RatingsResponse GetRatingsByAnswerId(int id);
        public RatingResponse GetAnswerRating(int id);
        public BaseResponse AddAnswerRating(int id);







    }
}
