using System.Text.Json.Serialization;

namespace WinFormsApp1
{
    internal class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime createdOn { get; set; }
        public PostStatus status { get; set; }
        public User user { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    internal enum PostStatus {
        PENDING,
        PUBLISHED,
        REMOVED
    }
}
