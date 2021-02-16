using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UserImportModel
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = default!;

        [JsonPropertyName("name")]
        public NameModel Name { get; set; } = default!;

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; } = default!;

        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;

        [JsonPropertyName("dob")]
        public DobModel Dob { get; set; } = default!;

        [JsonPropertyName("registered")]
        public RegisteredModel Registered { get; set; } = default!;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = default!;

        [JsonPropertyName("cell")]
        public string Cell { get; set; } = default!;

        [JsonPropertyName("picture")]
        public PictureModel Picture { get; set; } = default!;
    }
}
