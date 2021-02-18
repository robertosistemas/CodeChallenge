using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UserImportModel
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [JsonPropertyName("name")]
        public NameModel Name { get; set; } = null!;

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; } = null!;

        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("dob")]
        public DobModel Dob { get; set; } = null!;

        [JsonPropertyName("registered")]
        public RegisteredModel Registered { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = null!;

        [JsonPropertyName("cell")]
        public string Cell { get; set; } = null!;

        [JsonPropertyName("picture")]
        public PictureModel Picture { get; set; } = null!;
    }
}
