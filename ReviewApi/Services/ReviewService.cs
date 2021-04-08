using MongoDB.Driver;
using ReviewApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewApi.Services
{
    public class ReviewService
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            _reviews = database.GetCollection<Review>(settings.ReviewsCollection);
        }

        public List<Review> Get() =>
            _reviews.Find(review => true).ToList();

        public Review Get(string reviewId) =>
            _reviews.Find<Review>(review => review.ReviewId == reviewId).FirstOrDefault();
    }
}
