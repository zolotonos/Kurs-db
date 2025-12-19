using Microsoft.AspNetCore.Mvc;
using Kurs_db.Services;
using Kurs_db.Models;

namespace Kurs_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            try
            {
                var createdReview = await _reviewService.AddReviewAsync(review);
                return Ok(createdReview);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductReviews(Guid productId)
        {
            var reviews = await _reviewService.GetReviewsByProductAsync(productId);
            return Ok(reviews);
        }
        
        [HttpGet("product/{productId}/stats")]
        public async Task<IActionResult> GetProductStats(Guid productId)
        {
            var avg = await _reviewService.GetAverageRatingAsync(productId);
            var dist = await _reviewService.GetRatingDistributionAsync(productId);

            return Ok(new 
            { 
                ProductId = productId, 
                AverageRating = Math.Round(avg, 1),
                RatingDistribution = dist 
            });
        }
    }
}