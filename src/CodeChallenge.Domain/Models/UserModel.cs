using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Id = Guid.NewGuid();
            TelephoneNumbers = new List<string>();
            MobileNumbers = new List<string>();
            Location = new LocationModel() { Region = string.Empty };
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; } = default!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = default!;

        [JsonPropertyName("name")]
        public NameModel Name { get; set; } = default!;

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; } = default!;

        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; } = default!;

        [JsonPropertyName("registered")]
        public DateTime Registered { get; set; } = default!;

        [JsonPropertyName("telephoneNumbers")]
        public List<string> TelephoneNumbers { get; set; } = default!;

        [JsonPropertyName("mobileNumbers")]
        public List<string> MobileNumbers { get; set; } = default!;

        [JsonPropertyName("picture")]
        public PictureModel Picture { get; set; } = default!;

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; } = default!;
    }
}
