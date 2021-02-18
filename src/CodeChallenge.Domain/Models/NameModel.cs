using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class NameModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("first")]
        public string First { get; set; } = null!;

        [JsonPropertyName("last")]
        public string Last { get; set; } = null!;
    }
}
