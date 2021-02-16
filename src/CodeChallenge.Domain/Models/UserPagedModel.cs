using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UserPagedModel : PagedModel
    {
        [JsonPropertyName("region")]
        public string Region { get; set; } = default!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;
    }
}
