using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class CoordinatesDto
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}
