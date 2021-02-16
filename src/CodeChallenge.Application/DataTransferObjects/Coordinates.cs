using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class Coordinates
    {
        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }
    }
}
