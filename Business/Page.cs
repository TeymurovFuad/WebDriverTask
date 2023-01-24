using System.Text.Json.Serialization;

namespace Business
{
    public class Page
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        [JsonPropertyName("language")]
        public string? Language { get; set; }

        public Page(string? name = null, string? description = null, string? title = null, string? url = null, string? language = null)
        {
            Name = name;
            Description = description;
            Title = title;
            Url = url;
            Language = language;
        }
    }
}
