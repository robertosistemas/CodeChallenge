using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class TimezoneModel
    {
        [JsonPropertyName("offset")]
        public string Offset { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;
    }
}
