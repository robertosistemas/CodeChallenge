using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class UserDto
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public NameDto Name { get; set; }

        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("dob")]
        public DobDto Dob { get; set; }

        [JsonPropertyName("registered")]
        public RegisteredDto Registered { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("cell")]
        public string Cell { get; set; }

        [JsonPropertyName("picture")]
        public PictureDto Picture { get; set; }
    }
}
