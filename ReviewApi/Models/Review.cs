using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ReviewApi.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("review_id")]        
        public string ReviewId { get; set; }
        
        [BsonElement("text")]
        public string Text { get; set; }
        
        [BsonElement("rating")]
        public int Rating { get; set; }

        [BsonElement("date_created")]
        public DateTime DateCreated { get; set; }

        [BsonElement("user")]
        public User User { get; set; }

        [BsonElement("__v")]
        public int V { get; set; }

    }

    public class User
    {
        [BsonElement("user_id")]
        public string UserId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("photo_preview_url")]
        public string PhotoPreviewUrl { get; set; }
    }
}
