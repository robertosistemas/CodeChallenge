using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class UserPagedDto : PagedDto
    {
        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
