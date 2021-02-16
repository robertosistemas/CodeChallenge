using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class NameModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("first")]
        public string First { get; set; } = default!;

        [JsonPropertyName("last")]
        public string Last { get; set; } = default!;
    }
}
