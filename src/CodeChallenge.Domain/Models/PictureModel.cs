using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class PictureModel
    {
        [JsonPropertyName("large")]
        public string Large { get; set; } = default!;

        [JsonPropertyName("medium")]
        public string Medium { get; set; } = default!;

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; } = default!;
    }
}
