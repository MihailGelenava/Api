using Newtonsoft.Json;

namespace Models
{
    public class PostModel
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
        
        public PostModel() { }
        
        public PostModel(long userId, string title, string body) {
            this.UserId = userId;
            this.Title = title;
            this.Body = body;
        }

        public override bool Equals(object? obj)
        {
            return obj is PostModel model &&
                   UserId == model.UserId &&
                   Title == model.Title &&
                   Body == model.Body;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, Title, Body);
        }
    }
}
