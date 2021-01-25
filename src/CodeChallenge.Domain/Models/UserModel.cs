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
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public NameModel Name { get; set; }

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("registered")]
        public DateTime Registered { get; set; }

        [JsonPropertyName("telephoneNumbers")]
        public List<string> TelephoneNumbers { get; set; }

        [JsonPropertyName("mobileNumbers")]
        public List<string> MobileNumbers { get; set; }

        [JsonPropertyName("picture")]
        public PictureModel Picture { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }
    }
}
