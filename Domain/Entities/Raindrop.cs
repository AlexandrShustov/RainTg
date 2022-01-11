using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Raindrop
    {
        [JsonPropertyName("pleaseParse")]
        public object PleaseParse { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "link";

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
