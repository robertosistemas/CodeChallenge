using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class PictureModel
    {
        [JsonPropertyName("large")]
        public string Large { get; set; } = null!;

        [JsonPropertyName("medium")]
        public string Medium { get; set; } = null!;

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; } = null!;
    }
}
