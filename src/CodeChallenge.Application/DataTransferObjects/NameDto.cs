using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class NameDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
