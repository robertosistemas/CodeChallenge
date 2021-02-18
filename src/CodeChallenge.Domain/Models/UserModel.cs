using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UserModel
    {
        public UserModel()
        {
            TelephoneNumbers = new List<string>();
            MobileNumbers = new List<string>();
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [JsonPropertyName("name")]
        public NameModel Name { get; set; } = null!;

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; } = null!;

        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("registered")]
        public DateTime Registered { get; set; }

        [JsonPropertyName("telephoneNumbers")]
        public List<string> TelephoneNumbers { get; set; } = null!;

        [JsonPropertyName("mobileNumbers")]
        public List<string> MobileNumbers { get; set; } = null!;

        [JsonPropertyName("picture")]
        public PictureModel Picture { get; set; } = null!;

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; } = null!;
    }
}
