using Newtonsoft.Json;

namespace RestAPI.DTO
{
    public class PostsDTO
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
        
        public PostsDTO() { }
        
        public PostsDTO(long userId, string title, string body) {
            this.UserId = userId;
            this.Title = title;
            this.Body = body;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj as PostsDTO);
        }
        public bool Equals(PostsDTO other)
        {
            return this.UserId == other.UserId && this.Title == other.Title && this.Body == other.Body;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(UserId,Title,Body);
        }
    }
}
