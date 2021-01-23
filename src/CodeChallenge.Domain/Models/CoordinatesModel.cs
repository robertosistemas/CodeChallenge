using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class CoordinatesModel
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}
