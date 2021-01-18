using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UserPaged : Paged
    {
        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
