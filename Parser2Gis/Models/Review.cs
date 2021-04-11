using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Parser2Gis.Models
{
    public class Review
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("date_created")]
        public string DateCreated { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

    }

    public class User
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo_preview_urls")]
        public PhotoPreviewUrl PhotoPreviewUrl { get; set; }

    }

    public class PhotoPreviewUrl
    {
        [JsonProperty("1920x")]
        public string Photo1920 { get; set; }
    }

}