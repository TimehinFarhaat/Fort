namespace Fort.DTOs
{
    public class RatingDto
    {
        public int Value { get; set; }
        public int  Id { get; set; }
        public int  AnswerId { get; set; }
    }
    public class CreateRatingRequest
    {
        public int Value { get; set; }
    }

    public class UpdateRatingRequest
    {
        public int Value { get; set; }
    }

    public class RatingResponse : BaseResponse
    {

        public RatingDto Data { get; set; }
    }
    public class RatingsResponse : BaseResponse
    {

        public IList<RatingDto> Data { get; set; }
    }
}
