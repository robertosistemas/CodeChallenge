using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class LocationModel
    {
        [JsonPropertyName("region")]
        public string Region { get; set; } = null!;

        [JsonPropertyName("street")]
        public string Street { get; set; } = null!;

        [JsonPropertyName("city")]
        public string City { get; set; } = null!;

        [JsonPropertyName("state")]
        public string State { get; set; } = null!;

        [JsonPropertyName("postcode")]
        public int Postcode { get; set; }

        [JsonPropertyName("coordinates")]
        public CoordinatesModel Coordinates { get; set; } = null!;

        [JsonPropertyName("timezone")]
        public TimezoneModel Timezone { get; set; } = null!;
    }
}
