using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewApi.Models;
using ReviewApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly ReviewService _reviewsService;

        public ReviewsController(ReviewService  reviewService)
        {
            _reviewsService = reviewService;
        }
        // GET: ReviewsController
        [HttpGet]
        public ActionResult<List<Review>> Get() =>
            _reviewsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetReview")]
        public ActionResult<Review> Get(string reviewId) 
        {
            var review = _reviewsService.Get(reviewId);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }
         



    }
}
