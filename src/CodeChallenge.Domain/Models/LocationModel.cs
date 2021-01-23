using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class LocationModel
    {
        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postcode")]
        public int Postcode { get; set; }

        [JsonPropertyName("coordinates")]
        public CoordinatesModel Coordinates { get; set; }

        [JsonPropertyName("timezone")]
        public TimezoneModel Timezone { get; set; }
    }
}
