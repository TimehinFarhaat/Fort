using Fort.DTOs;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }


        [HttpPost("AddRating")]
        public IActionResult AddRating( CreateRatingRequest RatingRequestmodel, int id)
        {
            var result = _ratingService.AddRating(RatingRequestmodel, id);
            return Ok(result);
        }

        [HttpGet("GetRatingsByAnswerId")]
        public IActionResult GetRatingsByAnswerId(int id)
        {
            var result = _ratingService.GetRatingsByAnswerId(id);
            return Ok(result);
        }


        [HttpGet("GetAnswerRating")]
        public IActionResult GetAnswerRating(int id)
        {
            var result = _ratingService.GetAnswerRating(id);
            return Ok(result);
        }

        [HttpPost("AddAnswerRating")]
        public IActionResult AddAnswerRating(int id)
        {
            var result = _ratingService.AddAnswerRating( id);
            return Ok(result);
        }



    }
}
