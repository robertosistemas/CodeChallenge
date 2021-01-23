using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UserImportModel
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public NameModel Name { get; set; }

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("dob")]
        public DobModel Dob { get; set; }

        [JsonPropertyName("registered")]
        public RegisteredModel Registered { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("cell")]
        public string Cell { get; set; }

        [JsonPropertyName("picture")]
        public PictureModel Picture { get; set; }
    }
}
