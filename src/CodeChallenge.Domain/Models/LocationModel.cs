using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class LocationModel
    {
        [JsonPropertyName("region")]
        public string Region { get; set; } = default!;

        [JsonPropertyName("street")]
        public string Street { get; set; } = default!;

        [JsonPropertyName("city")]
        public string City { get; set; } = default!;

        [JsonPropertyName("state")]
        public string State { get; set; } = default!;

        [JsonPropertyName("postcode")]
        public int Postcode { get; set; } = default!;

        [JsonPropertyName("coordinates")]
        public CoordinatesModel Coordinates { get; set; } = default!;

        [JsonPropertyName("timezone")]
        public TimezoneModel Timezone { get; set; } = default!;
    }
}
