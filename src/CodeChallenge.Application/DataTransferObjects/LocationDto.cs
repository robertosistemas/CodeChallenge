using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class LocationDto
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
        public CoordinatesDto Coordinates { get; set; }

        [JsonPropertyName("timezone")]
        public TimezoneDto Timezone { get; set; }
    }
}
