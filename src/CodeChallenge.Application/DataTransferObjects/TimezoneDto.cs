using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class TimezoneDto
    {
        [JsonPropertyName("offset")]
        public string Offset { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
